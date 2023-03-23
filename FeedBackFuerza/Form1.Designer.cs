namespace RegistroPlatFuerzas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonArranca = new System.Windows.Forms.Button();
            this.buttonLecturaCero = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxFx = new System.Windows.Forms.TextBox();
            this.textBoxFy = new System.Windows.Forms.TextBox();
            this.textBoxFz = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAx = new System.Windows.Forms.TextBox();
            this.textBoxAy = new System.Windows.Forms.TextBox();
            this.textBoxTiempoRegistro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxFz1 = new System.Windows.Forms.TextBox();
            this.textBoxFz2 = new System.Windows.Forms.TextBox();
            this.textBoxFz3 = new System.Windows.Forms.TextBox();
            this.textBoxFz4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTargetNewtons = new System.Windows.Forms.TextBox();
            this.checkBoxGuardarPortapapeles = new System.Windows.Forms.CheckBox();
            this.checkBoxGuardarBioware = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCarpeta = new System.Windows.Forms.TextBox();
            this.textBoxNombreArchivo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxFrecuenciaRegistro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonReiniciarDAQ = new System.Windows.Forms.Button();
            this.textBoxNomArchivoConfig = new System.Windows.Forms.TextBox();
            this.textBoxNomPlate = new System.Windows.Forms.TextBox();
            this.buttonAjustarOffset = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBoxCalculandoOffset = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBoxGuardarCsv = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonArranca
            // 
            this.buttonArranca.Location = new System.Drawing.Point(178, 12);
            this.buttonArranca.Name = "buttonArranca";
            this.buttonArranca.Size = new System.Drawing.Size(75, 34);
            this.buttonArranca.TabIndex = 0;
            this.buttonArranca.Text = "Arranca";
            this.buttonArranca.UseVisualStyleBackColor = true;
            this.buttonArranca.Click += new System.EventHandler(this.buttonArranca_Click);
            // 
            // buttonLecturaCero
            // 
            this.buttonLecturaCero.Location = new System.Drawing.Point(15, 83);
            this.buttonLecturaCero.Name = "buttonLecturaCero";
            this.buttonLecturaCero.Size = new System.Drawing.Size(75, 23);
            this.buttonLecturaCero.TabIndex = 1;
            this.buttonLecturaCero.Text = "Lectura cero";
            this.buttonLecturaCero.UseVisualStyleBackColor = true;
            this.buttonLecturaCero.Click += new System.EventHandler(this.buttonLecturaCero_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxFx
            // 
            this.textBoxFx.Location = new System.Drawing.Point(307, 60);
            this.textBoxFx.Name = "textBoxFx";
            this.textBoxFx.Size = new System.Drawing.Size(65, 20);
            this.textBoxFx.TabIndex = 5;
            // 
            // textBoxFy
            // 
            this.textBoxFy.Location = new System.Drawing.Point(307, 86);
            this.textBoxFy.Name = "textBoxFy";
            this.textBoxFy.Size = new System.Drawing.Size(65, 20);
            this.textBoxFy.TabIndex = 5;
            // 
            // textBoxFz
            // 
            this.textBoxFz.Location = new System.Drawing.Point(307, 112);
            this.textBoxFz.Name = "textBoxFz";
            this.textBoxFz.Size = new System.Drawing.Size(65, 20);
            this.textBoxFz.TabIndex = 5;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(307, 34);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(65, 20);
            this.textBoxTime.TabIndex = 5;
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Location = new System.Drawing.Point(307, 8);
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(65, 20);
            this.textBoxTimer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "tiempo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ax";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ay";
            // 
            // textBoxAx
            // 
            this.textBoxAx.Location = new System.Drawing.Point(415, 11);
            this.textBoxAx.Name = "textBoxAx";
            this.textBoxAx.Size = new System.Drawing.Size(45, 20);
            this.textBoxAx.TabIndex = 5;
            // 
            // textBoxAy
            // 
            this.textBoxAy.Location = new System.Drawing.Point(415, 37);
            this.textBoxAy.Name = "textBoxAy";
            this.textBoxAy.Size = new System.Drawing.Size(45, 20);
            this.textBoxAy.TabIndex = 5;
            // 
            // textBoxTiempoRegistro
            // 
            this.textBoxTiempoRegistro.Location = new System.Drawing.Point(115, 12);
            this.textBoxTiempoRegistro.Name = "textBoxTiempoRegistro";
            this.textBoxTiempoRegistro.Size = new System.Drawing.Size(57, 20);
            this.textBoxTiempoRegistro.TabIndex = 2;
            this.textBoxTiempoRegistro.Text = "8000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "tiempo registro (ms)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(967, 320);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fz1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Fz2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(388, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fz3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Fz4";
            // 
            // textBoxFz1
            // 
            this.textBoxFz1.Location = new System.Drawing.Point(418, 58);
            this.textBoxFz1.Name = "textBoxFz1";
            this.textBoxFz1.Size = new System.Drawing.Size(42, 20);
            this.textBoxFz1.TabIndex = 10;
            // 
            // textBoxFz2
            // 
            this.textBoxFz2.Location = new System.Drawing.Point(418, 79);
            this.textBoxFz2.Name = "textBoxFz2";
            this.textBoxFz2.Size = new System.Drawing.Size(42, 20);
            this.textBoxFz2.TabIndex = 10;
            // 
            // textBoxFz3
            // 
            this.textBoxFz3.Location = new System.Drawing.Point(418, 101);
            this.textBoxFz3.Name = "textBoxFz3";
            this.textBoxFz3.Size = new System.Drawing.Size(42, 20);
            this.textBoxFz3.TabIndex = 10;
            // 
            // textBoxFz4
            // 
            this.textBoxFz4.Location = new System.Drawing.Point(418, 122);
            this.textBoxFz4.Name = "textBoxFz4";
            this.textBoxFz4.Size = new System.Drawing.Size(42, 20);
            this.textBoxFz4.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(481, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Target (N)";
            // 
            // textBoxTargetNewtons
            // 
            this.textBoxTargetNewtons.Location = new System.Drawing.Point(542, 7);
            this.textBoxTargetNewtons.Name = "textBoxTargetNewtons";
            this.textBoxTargetNewtons.Size = new System.Drawing.Size(42, 20);
            this.textBoxTargetNewtons.TabIndex = 10;
            this.textBoxTargetNewtons.Text = "700.0";
            // 
            // checkBoxGuardarPortapapeles
            // 
            this.checkBoxGuardarPortapapeles.AutoSize = true;
            this.checkBoxGuardarPortapapeles.Location = new System.Drawing.Point(574, 102);
            this.checkBoxGuardarPortapapeles.Name = "checkBoxGuardarPortapapeles";
            this.checkBoxGuardarPortapapeles.Size = new System.Drawing.Size(143, 17);
            this.checkBoxGuardarPortapapeles.TabIndex = 14;
            this.checkBoxGuardarPortapapeles.Text = "Guardar en portapapeles";
            this.checkBoxGuardarPortapapeles.UseVisualStyleBackColor = true;
            // 
            // checkBoxGuardarBioware
            // 
            this.checkBoxGuardarBioware.AutoSize = true;
            this.checkBoxGuardarBioware.Checked = true;
            this.checkBoxGuardarBioware.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGuardarBioware.Location = new System.Drawing.Point(574, 125);
            this.checkBoxGuardarBioware.Name = "checkBoxGuardarBioware";
            this.checkBoxGuardarBioware.Size = new System.Drawing.Size(143, 17);
            this.checkBoxGuardarBioware.TabIndex = 14;
            this.checkBoxGuardarBioware.Text = "Guardar archivo Bioware";
            this.checkBoxGuardarBioware.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FeedBackFuerza.Properties.Resources.LogoBiomecIngles;
            this.pictureBox2.Location = new System.Drawing.Point(783, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(481, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Carpeta";
            // 
            // textBoxCarpeta
            // 
            this.textBoxCarpeta.Location = new System.Drawing.Point(542, 33);
            this.textBoxCarpeta.Name = "textBoxCarpeta";
            this.textBoxCarpeta.Size = new System.Drawing.Size(398, 20);
            this.textBoxCarpeta.TabIndex = 10;
            // 
            // textBoxNombreArchivo
            // 
            this.textBoxNombreArchivo.Location = new System.Drawing.Point(542, 58);
            this.textBoxNombreArchivo.Name = "textBoxNombreArchivo";
            this.textBoxNombreArchivo.Size = new System.Drawing.Size(164, 20);
            this.textBoxNombreArchivo.TabIndex = 10;
            this.textBoxNombreArchivo.Text = "Registro";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(481, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Nombre";
            // 
            // textBoxFrecuenciaRegistro
            // 
            this.textBoxFrecuenciaRegistro.Location = new System.Drawing.Point(115, 38);
            this.textBoxFrecuenciaRegistro.Name = "textBoxFrecuenciaRegistro";
            this.textBoxFrecuenciaRegistro.Size = new System.Drawing.Size(57, 20);
            this.textBoxFrecuenciaRegistro.TabIndex = 2;
            this.textBoxFrecuenciaRegistro.Text = "1000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Frecuencia (Hz)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 20);
            this.textBox1.TabIndex = 16;
            // 
            // buttonReiniciarDAQ
            // 
            this.buttonReiniciarDAQ.Location = new System.Drawing.Point(15, 112);
            this.buttonReiniciarDAQ.Name = "buttonReiniciarDAQ";
            this.buttonReiniciarDAQ.Size = new System.Drawing.Size(75, 39);
            this.buttonReiniciarDAQ.TabIndex = 17;
            this.buttonReiniciarDAQ.Text = "Reiniciar DAQ";
            this.buttonReiniciarDAQ.UseVisualStyleBackColor = true;
            this.buttonReiniciarDAQ.Click += new System.EventHandler(this.buttonReiniciarDAQ_Click);
            // 
            // textBoxNomArchivoConfig
            // 
            this.textBoxNomArchivoConfig.Location = new System.Drawing.Point(96, 105);
            this.textBoxNomArchivoConfig.Name = "textBoxNomArchivoConfig";
            this.textBoxNomArchivoConfig.Size = new System.Drawing.Size(129, 20);
            this.textBoxNomArchivoConfig.TabIndex = 18;
            this.textBoxNomArchivoConfig.Text = "config-FeedBackFuerza.xml";
            // 
            // textBoxNomPlate
            // 
            this.textBoxNomPlate.Location = new System.Drawing.Point(96, 131);
            this.textBoxNomPlate.Name = "textBoxNomPlate";
            this.textBoxNomPlate.Size = new System.Drawing.Size(100, 20);
            this.textBoxNomPlate.TabIndex = 19;
            this.textBoxNomPlate.Text = "Kistler Grande2";
            // 
            // buttonAjustarOffset
            // 
            this.buttonAjustarOffset.Location = new System.Drawing.Point(109, 67);
            this.buttonAjustarOffset.Name = "buttonAjustarOffset";
            this.buttonAjustarOffset.Size = new System.Drawing.Size(69, 34);
            this.buttonAjustarOffset.TabIndex = 20;
            this.buttonAjustarOffset.Text = "Ajustar Offset";
            this.buttonAjustarOffset.UseVisualStyleBackColor = true;
            this.buttonAjustarOffset.Click += new System.EventHandler(this.buttonAjustarOffset_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(302, 382);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 25);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Visible = false;
            // 
            // richTextBoxCalculandoOffset
            // 
            this.richTextBoxCalculandoOffset.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxCalculandoOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxCalculandoOffset.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxCalculandoOffset.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCalculandoOffset.ForeColor = System.Drawing.Color.Red;
            this.richTextBoxCalculandoOffset.Location = new System.Drawing.Point(241, 281);
            this.richTextBoxCalculandoOffset.Name = "richTextBoxCalculandoOffset";
            this.richTextBoxCalculandoOffset.Size = new System.Drawing.Size(485, 48);
            this.richTextBoxCalculandoOffset.TabIndex = 28;
            this.richTextBoxCalculandoOffset.Text = "        Ajustando fuerzas, espera...\n";
            this.richTextBoxCalculandoOffset.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(212, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "label16";
            // 
            // checkBoxGuardarCsv
            // 
            this.checkBoxGuardarCsv.AutoSize = true;
            this.checkBoxGuardarCsv.Checked = true;
            this.checkBoxGuardarCsv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGuardarCsv.Location = new System.Drawing.Point(574, 148);
            this.checkBoxGuardarCsv.Name = "checkBoxGuardarCsv";
            this.checkBoxGuardarCsv.Size = new System.Drawing.Size(125, 17);
            this.checkBoxGuardarCsv.TabIndex = 30;
            this.checkBoxGuardarCsv.Text = "Guardar archivo .csv";
            this.checkBoxGuardarCsv.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 502);
            this.Controls.Add(this.checkBoxGuardarCsv);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.richTextBoxCalculandoOffset);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonAjustarOffset);
            this.Controls.Add(this.textBoxNomPlate);
            this.Controls.Add(this.textBoxNomArchivoConfig);
            this.Controls.Add(this.buttonReiniciarDAQ);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBoxGuardarBioware);
            this.Controls.Add(this.checkBoxGuardarPortapapeles);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxFz4);
            this.Controls.Add(this.textBoxNombreArchivo);
            this.Controls.Add(this.textBoxCarpeta);
            this.Controls.Add(this.textBoxTargetNewtons);
            this.Controls.Add(this.textBoxFz1);
            this.Controls.Add(this.textBoxFz2);
            this.Controls.Add(this.textBoxFz3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.textBoxAy);
            this.Controls.Add(this.textBoxAx);
            this.Controls.Add(this.textBoxFz);
            this.Controls.Add(this.textBoxFy);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.textBoxFx);
            this.Controls.Add(this.textBoxFrecuenciaRegistro);
            this.Controls.Add(this.textBoxTiempoRegistro);
            this.Controls.Add(this.buttonLecturaCero);
            this.Controls.Add(this.buttonArranca);
            this.Name = "Form1";
            this.Text = "FeedBackFuerza    v1.2                     (José Luis López Elvira, 2023)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonArranca;
        private System.Windows.Forms.Button buttonLecturaCero;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxFx;
        private System.Windows.Forms.TextBox textBoxFy;
        private System.Windows.Forms.TextBox textBoxFz;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAx;
        private System.Windows.Forms.TextBox textBoxAy;
        private System.Windows.Forms.TextBox textBoxTiempoRegistro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxFz1;
        private System.Windows.Forms.TextBox textBoxFz2;
        private System.Windows.Forms.TextBox textBoxFz3;
        private System.Windows.Forms.TextBox textBoxFz4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTargetNewtons;
        private System.Windows.Forms.CheckBox checkBoxGuardarPortapapeles;
        private System.Windows.Forms.CheckBox checkBoxGuardarBioware;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCarpeta;
        private System.Windows.Forms.TextBox textBoxNombreArchivo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxFrecuenciaRegistro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonReiniciarDAQ;
        private System.Windows.Forms.TextBox textBoxNomArchivoConfig;
        private System.Windows.Forms.TextBox textBoxNomPlate;
        private System.Windows.Forms.Button buttonAjustarOffset;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBoxCalculandoOffset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBoxGuardarCsv;
    }
}

