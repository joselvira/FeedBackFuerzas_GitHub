using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;   //para el StopWatch
using System.IO;

using DataServerLib;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegistroPlatFuerzas
{
    public partial class Form1 : Form
    {

        DaqControl daq;
        DeviceCollection dc;
        IPlate plate;

        Array Time, Fx, Fy, Fz, Ax, Ay;
        Array Fz1, Fz2, Fz3, Fz4;

        int PrevScan;
        int TiempoRegistro = 8000;
        int FrecuenciaRegistro = 1000;

        private string chSeparador = ","; //"\t";

        PointF PosCOP;
        PointF PosTarget;
        int RadioBola = 10;

        PointF AmplitudMov;
        PointF FrecuenciaMov;
        float TargetNewtons;

        private Stopwatch timer = new Stopwatch();
        private float GameTime;
        private double lastTime;
        private long frameCounter;
        private int Estado = 0;     //0=inactivo; 1= registrando datos; 2=ajustando Offset

        private int UpdateInterval_ms = 10;
        private string rutaConfig = @"XML\config-FeedBackFuerza.xml";

        private float OffsetFx = 0.0f;
        private float OffsetFy = 0.0f;
        private float OffsetFz = 0.0f;
            
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonReiniciarDAQ_Click(object sender, EventArgs e)
        {
            IniciaDaq(UpdateInterval_ms, @"XML\"+ textBoxNomArchivoConfig.Text);
        }

        private void buttonAjustarOffset_Click(object sender, EventArgs e)
        {
            daq.Start(FrecuenciaRegistro, 3 * FrecuenciaRegistro, TriggerType.trigImmediate, RangeType.rngBIP10VOLTS);

            textBox1.Text = "Ajustando Offset...";
            textBox1.Refresh();
            buttonArranca.Enabled = false;
            buttonAjustarOffset.Enabled = false;
            Cursor = Cursors.WaitCursor;
            progressBar1.Value = 0;
            progressBar1.Maximum = 3 * 10; //los segundos x 10 para que sea más sensible
            progressBar1.Visible = true;
            progressBar1.Show();
            richTextBoxCalculandoOffset.Visible = true;

            Estado = 2;
            //while (daq.Running) ;

            timer1.Enabled = true;
            timer1.Interval = UpdateInterval_ms;
            timer.Reset();
            timer.Start();
        }

        private void IniciaDaq(int UpdateInterval_ms, string rutaConfig)
        {
            //PARA ARRANCAR LA 2ª PLATAFORMA, EN ARCHIVO config-FeedBackFuerza.xml FIJAR EL CANAL INICIAL: <StartChannel>9</StartChannel>


            //daq = new DaqControl();
            //declare a dataserver object, get a DaqControl object from server factory
            DataServer server = new DataServer();
            //create object, assigning a configuration file, board type, and Instacal board number
            //TODO:
            //set path to XML configuration file
            //set board type and MCC Instacal board number
            daq = server.CreateDaqObject(rutaConfig, BoardType.brdKistler5691A1, 0);//@"C:\Archivos de programa\Kistler\DataServer\Samples\XML\config-Range1.xml"


            //set the internal buffer to update every 50 ms
            IDaqAdvanced adv;
            adv = (IDaqAdvanced)(daq);
            //=new IDaqAdvanced(DaqControl(daq)); 

            //Dim adv As IDaqAdvanced = daq

            //adv.SetMCCParameters(1000, UpdateInterval_ms)
            adv.SetMCCParameters(FrecuenciaRegistro, UpdateInterval_ms);
            adv.SetLocalParameters(65);



            //enable measure
            daq.MeasureOn();


            dc = daq.GetDeviceCollection();
            plate = dc.get_DeviceByName(textBoxNomPlate.Text);

            //read offsets
            textBox1.Text = "Inicio lectura cero";
            daq.ReadOffsets(RangeType.rngBIP10VOLTS);
            textBox1.Text = "Leido el cero";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            timer1.Enabled = false;
            timer1.Interval = UpdateInterval_ms;

            AmplitudMov.X = 400;
            AmplitudMov.Y = 100;
            FrecuenciaMov.X = 0.2f;
            FrecuenciaMov.Y = 0.1f;
            GameTime = 0.0f;

            textBoxCarpeta.Text = Application.StartupPath;



            try
            {
                IniciaDaq(UpdateInterval_ms, rutaConfig);

                /*
                //daq = new DaqControl();
                //declare a dataserver object, get a DaqControl object from server factory
                DataServer server = new DataServer();
                //create object, assigning a configuration file, board type, and Instacal board number
                //TODO:
                //set path to XML configuration file
                //set board type and MCC Instacal board number
                daq = server.CreateDaqObject(@"XML\config-FeedBackFuerza.xml", BoardType.brdKistler5691A1, 0);//@"C:\Archivos de programa\Kistler\DataServer\Samples\XML\config-Range1.xml"


                //set the internal buffer to update every 50 ms
                IDaqAdvanced adv;
                adv = (IDaqAdvanced)(daq);
                //=new IDaqAdvanced(DaqControl(daq)); 

                //Dim adv As IDaqAdvanced = daq

                //adv.SetMCCParameters(1000, UpdateInterval_ms)
                adv.SetMCCParameters(FrecuenciaRegistro, UpdateInterval_ms);
                adv.SetLocalParameters(65);



                //enable measure
                daq.MeasureOn();


                dc = daq.GetDeviceCollection();
                plate = dc.get_DeviceByName("Kistler Grande1");

                //read offsets
                textBox1.Text = "Inicio lectura cero";
                daq.ReadOffsets(RangeType.rngBIP10VOLTS);
                textBox1.Text = "Leido el cero";
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede establecer la conexión.\nComprueba que el DAQ está encendido.\n" + ex.Message, "Error de lectura",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //set to reset
            if(daq!=null)
                daq.MeasureOff();
        }

        private void buttonArranca_Click(object sender, EventArgs e)
        {
            PrevScan = 0;
            AmplitudMov.X = 400;
            AmplitudMov.Y = 0;
            FrecuenciaMov.X = 0.2f;
            FrecuenciaMov.Y = 0.0f;
            GameTime = 0.0f;

            TiempoRegistro = int.Parse(textBoxTiempoRegistro.Text);
            FrecuenciaRegistro = int.Parse(textBoxFrecuenciaRegistro.Text);
            TargetNewtons = float.Parse(textBoxTargetNewtons.Text);

            if (daq.Running)
            {
                daq.Stop();
                buttonArranca.Text = "Arranca";
                return;
            }

            //Start acquisition
            daq.Start(FrecuenciaRegistro, TiempoRegistro/1000*FrecuenciaRegistro, TriggerType.trigImmediate, RangeType.rngBIP10VOLTS);

            //enable the time, disable the start button
            timer1.Enabled = true;
            timer.Reset();
            timer.Start();
            //buttonArranca.Enabled = false;

            Estado = 1;

            SystemSounds.Beep.Play();

            textBox1.Text = "apretado botón";
            this.Refresh();

            //timer1.Start();

            textBox1.Text = "registrando";
            this.Refresh();

            ////Wait until done
            //while(daq.Running)
            //    ;

            //textBox1.Text = "Acabado";
            buttonArranca.Text = "Para";


        }

        private void AddData()
        {

            int currScan = daq.LastAvailableScan;
            int size = currScan - PrevScan;

            if (size == 0)
                return;

            /*
             * Time = plate.arrTime(1000, PrevScan, currScan);
            Fx = plate.arrFx(PrevScan, currScan);
            Fy = plate.arrFy(PrevScan, currScan);
            Fz = plate.arrFz(PrevScan, currScan);
            Ax = plate.arrAx(PrevScan, currScan);
            Ay = plate.arrAy(PrevScan, currScan);
                        
            Fz1 = plate.arrVoltage(5, PrevScan, currScan);
            */

            //    'For i = LBound(Fzarr) To UBound(Fzarr)
            //    '    Fzarr(i)
            //    'Next i

            PosCOP.X = (float)plate.get_Ay(currScan);
            PosCOP.Y = (float)plate.get_Ax(currScan);
            
            textBoxTimer.Text = timer1.Interval.ToString();

            textBoxTime.Text = plate.get_Time(FrecuenciaRegistro,currScan).ToString("f3");
            textBoxFx.Text = (plate.get_Fx(currScan)- OffsetFx).ToString("f1");// Fx.GetValue(1).ToString();
            textBoxFy.Text = (plate.get_Fy(currScan) - OffsetFy).ToString("f1");
            textBoxFz.Text = (plate.get_Fz(currScan) - OffsetFz).ToString("f1");
            textBoxAx.Text = plate.get_Ax(currScan).ToString("f1");
            textBoxAy.Text = plate.get_Ay(currScan).ToString("f1");

            textBoxFz1.Text = plate.get_Voltage(5, currScan).ToString("f4");// Fz1.GetValue(1).ToString();
            textBoxFz2.Text = plate.get_Voltage(6, currScan).ToString("f4");
            textBoxFz3.Text = plate.get_Voltage(7, currScan).ToString("f4");// Fz1.GetValue(1).ToString();
            textBoxFz4.Text = plate.get_Voltage(8, currScan).ToString("f4");


            PrevScan = currScan;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            double elapsedTime = GameTime - lastTime;
            lastTime = GameTime;

            GameTime = timer.ElapsedMilliseconds / 1000.0f;

            if (Estado == 2)
                progressBar1.Value = (int)(GameTime * 10);

            //Carga los nuevos datos de la plataforma
            AddData();

            //pinta la nueva posición
            pictureBox1.Invalidate();

            if (!daq.Running)
            {
                buttonArranca.Enabled = true;
                timer1.Stop();
                timer1.Enabled = false;
                timer.Stop();


                if (Estado == 2)
                {
                    CalculaOffsetFuerzas();

                    Cursor = Cursors.Default;
                    buttonAjustarOffset.Enabled = true;
                    progressBar1.Visible = false;
                    richTextBoxCalculandoOffset.Visible = false;
                }
                else if (Estado == 1)
                {
                    textBox1.Text = "Registrado";

                    //Al acabar, registra en portapapeles
                    string registro = "";
                    //Time = plate.arrTime(1000, 0, TiempoRegistro - 1);
                    //Fx = plate.arrFx(0, TiempoRegistro - 1);
                    //Fy = plate.arrFy(0, TiempoRegistro - 1);
                    //Fz = plate.arrFz(0, TiempoRegistro - 1);
                    //Ax = plate.arrAx(0, TiempoRegistro - 1);
                    //Ay = plate.arrAy(0, TiempoRegistro - 1);

                    if (checkBoxGuardarPortapapeles.Checked)
                    {
                        for (int i = 0; i < (TiempoRegistro / 1000 * FrecuenciaRegistro); i++)
                        {
                            registro += string.Format("{0:0.0000}\t{1:0.00000000}\t{2:0.00000000}\t{3:0.00000000}\t{4:0.00000000}\t{5:0.00000000}\n", plate.get_Time(FrecuenciaRegistro, i), plate.get_Voltage(5, i), plate.get_Voltage(6, i), plate.get_Voltage(7, i), plate.get_Voltage(8, i), plate.get_Fz(i));
                        }
                        Clipboard.SetDataObject(registro, true);
                    }

                    if (checkBoxGuardarBioware.Checked)
                    {
                        string carpeta = textBoxCarpeta.Text;
                        string nombre = textBoxNombreArchivo.Text;
                        string nomArchivo = "";
                        int numArchivo = 0;

                        do
                        {
                            if (numArchivo < 10)
                                nomArchivo = carpeta + "\\" + nombre + "00" + numArchivo.ToString() + ".dat";
                            else if (numArchivo < 100)
                                nomArchivo = carpeta + "\\" + nombre + "0" + numArchivo.ToString() + ".dat";
                            else nomArchivo = carpeta + "\\" + nombre + numArchivo.ToString() + ".dat";
                            numArchivo++;
                        } while (File.Exists(nomArchivo));

                        daq.SaveBioWareFile(nomArchivo);
                        
                        /*
                        FileStream stmRecords = new FileStream(nomArchivo, FileMode.Create, FileAccess.Write, FileShare.None);
                        StreamWriter stmWriter = new StreamWriter(stmRecords);

                        stmWriter.WriteLine(registro);

                        stmWriter.Flush();
                        stmWriter.Close();
                        */

                    }

                    if (checkBoxGuardarCsv.Checked)
                    {
                        string carpeta = textBoxCarpeta.Text;
                        string nombre = textBoxNombreArchivo.Text;
                        string nomArchivo = "";
                        int numArchivo = 0;

                        do
                        {
                            if (numArchivo < 10)
                                nomArchivo = carpeta + "\\" + nombre + "00" + numArchivo.ToString() + ".csv";
                            else if (numArchivo < 100)
                                nomArchivo = carpeta + "\\" + nombre + "0" + numArchivo.ToString() + ".csv";
                            else nomArchivo = carpeta + "\\" + nombre + numArchivo.ToString() + ".csv";
                            numArchivo++;
                        } while (File.Exists(nomArchivo));

                        try
                        {
                            using (StreamWriter sw = new StreamWriter(nomArchivo))
                            {
                                Cursor = Cursors.WaitCursor;
                                progressBar1.Value = 0;
                                progressBar1.Maximum = TiempoRegistro * FrecuenciaRegistro;
                                progressBar1.Visible = true;
                                textBox1.Text = "Guardando datos...";
                                textBox1.Refresh();


                                //Escribe la cabecera
                                sw.WriteLine("tiempo, Fx, Fy, Fz");

                                //Escribe los datos
                                float X, Y, Z;
                                int NumDecimales = 4;// int.Parse(textBoxNumDecimales.Text);

                                for (int i = 0; i < (3 * FrecuenciaRegistro); i++)
                                {
                                    X = plate.get_Fx(i) - OffsetFx;
                                    Y = plate.get_Fy(i) - OffsetFy;
                                    Z = plate.get_Fz(i) - OffsetFz;

                        
                                    //linea += string.Format(@"{0}{1}{2}{3}{4}{5}{6}{7}{8}", plate.get_Time(FrecuenciaRegistro, i).ToString("f" + NumDecimales.ToString()), chSeparador, plate.get_Ay(i).ToString("f" + NumDecimales.ToString()), chSeparador, plate.get_Ax(i).ToString("f" + NumDecimales.ToString()), chSeparador, (targetX + OffsetPantalla.X).ToString("f" + NumDecimales.ToString()), chSeparador, (targetY + OffsetPantalla.Y).ToString("f" + NumDecimales.ToString()));
                                    sw.WriteLine(string.Format(@"{0}{1}{2}{3}{4}{5}{6}", ((float)(i) / FrecuenciaRegistro).ToString("f" + NumDecimales.ToString()), chSeparador, X.ToString("f" + NumDecimales.ToString()), chSeparador, Y.ToString("f" + NumDecimales.ToString()), chSeparador, Z.ToString("f" + NumDecimales.ToString())));


                                    progressBar1.Value++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrido algún error al guardar el archivo\n" + ex.Message, "Error de escritura",
                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Text = "Fallo de escritura";
                        }

                        Cursor = Cursors.Default;
                        progressBar1.Visible = false;
                        textBox1.Text = "Datos guardados";
                        textBox1.Refresh();
                    }
                }
                Estado = 0;
                buttonArranca.Text = "Arranca";
            }

        }

        private void CalculaOffsetFuerzas()
        {
            textBox1.Text = "Offset calculado";
            textBox1.Refresh();

            double promedioFx, promedioFy, promedioFz;
            int contador = 0;

            promedioFx = promedioFy = promedioFz = 0.0;

            for (int i = 0; i < (3 * FrecuenciaRegistro); i++) //Registra 3 s
            {
                contador++;

                
                promedioFx += plate.get_Fx(i);
                promedioFy += plate.get_Fy(i);
                promedioFz += plate.get_Fz(i);

            }
            OffsetFz = (float)(promedioFz / (double)(3 * FrecuenciaRegistro));
            label16.Text = OffsetFz.ToString();

            //ActualizaTrayectoria(); //aunque es redundante...

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Estado == 1)
            {
                //e.Graphics.DrawRectangle(new Pen(Color.Red), (pictureBox1.Width - 800)/2 , 10, (pictureBox1.Width - 800) / 2 + 800, 600);
                int altoCienPorCien = 600;
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), 100, pictureBox1.Height - altoCienPorCien - 10, 50, altoCienPorCien - 10);

                if (daq != null && daq.Running)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), 100 + 75, pictureBox1.Height - (int)((plate.get_Fz(daq.LastAvailableScan) - OffsetFz) * altoCienPorCien / TargetNewtons) - 10, 50, (int)((plate.get_Fz(daq.LastAvailableScan) - OffsetFz)* altoCienPorCien / TargetNewtons) - 10);

                }
            }
        }

        private void buttonLecturaCero_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Inicio lectura cero";
            this.Refresh();
            daq.ReadOffsets(RangeType.rngBIP10VOLTS);
            textBox1.Text = "Leido el cero";
        }

       

    }
}
