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

        private int UpdateInterval_ms = 10;
        private string rutaConfig = @"XML\config-FeedBackFuerza.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonReiniciarDAQ_Click(object sender, EventArgs e)
        {
            IniciaDaq(UpdateInterval_ms, rutaConfig);
        }

        public void IniciaDaq(int UpdateInterval_ms, string rutaConfig)
        {
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

            //Start acquisition
            daq.Start(FrecuenciaRegistro, TiempoRegistro/1000*FrecuenciaRegistro, TriggerType.trigImmediate, RangeType.rngBIP10VOLTS);

            //enable the time, disable the start button
            timer1.Enabled = true;
            timer.Reset();
            timer.Start();
            buttonArranca.Enabled = false;

            textBox1.Text = "apretado botón";
            this.Refresh();

            //timer1.Start();

            textBox1.Text = "registrando";
            this.Refresh();

            ////Wait until done
            //while(daq.Running)
            //    ;

            textBox1.Text = "Acabado";


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

            textBoxTime.Text = plate.get_Time(FrecuenciaRegistro,currScan).ToString(".2f");
            textBoxFx.Text = plate.get_Fx(currScan).ToString(".2f");// Fx.GetValue(1).ToString();
            textBoxFy.Text = plate.get_Fy(currScan).ToString(".2f");
            textBoxFz.Text = plate.get_Fz(currScan).ToString(".2f");
            textBoxAx.Text = plate.get_Ax(currScan).ToString(".2f");
            textBoxAy.Text = plate.get_Ay(currScan).ToString(".2f");

            textBoxFz1.Text = plate.get_Voltage(5, currScan).ToString();// Fz1.GetValue(1).ToString();
            textBoxFz2.Text = plate.get_Voltage(6, currScan).ToString();
            textBoxFz3.Text = plate.get_Voltage(7, currScan).ToString();// Fz1.GetValue(1).ToString();
            textBoxFz4.Text = plate.get_Voltage(8, currScan).ToString();


            PrevScan = currScan;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            double elapsedTime = GameTime - lastTime;
            lastTime = GameTime;

            GameTime = timer.ElapsedMilliseconds / 1000.0f;

           
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
                    for (int i = 0; i < (TiempoRegistro/1000*FrecuenciaRegistro); i++)
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
                            nomArchivo = carpeta +"\\"+ nombre + "00" + numArchivo.ToString() + ".dat";
                        else if (numArchivo < 100)
                            nomArchivo = carpeta + "\\"+nombre + "0" + numArchivo.ToString() + ".dat";
                        else nomArchivo = carpeta + "\\"+nombre + numArchivo.ToString() + ".dat";
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
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(new Pen(Color.Red), (pictureBox1.Width - 800)/2 , 10, (pictureBox1.Width - 800) / 2 + 800, 600);
            int altoCienPorCien = 600;
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 100, pictureBox1.Height - altoCienPorCien-10, 50, altoCienPorCien-10);

            if (daq!=null && daq.Running)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), 100 + 75, pictureBox1.Height - (int)(plate.get_Fz(daq.LastAvailableScan) * altoCienPorCien / TargetNewtons) - 10, 50, (int)(plate.get_Fz(daq.LastAvailableScan) * altoCienPorCien / TargetNewtons) - 10);
                
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
