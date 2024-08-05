namespace BOTSwapper
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tmrRefresh = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            txtTicker1Ask = new TextBox();
            txtTicker2Ask = new TextBox();
            txtTicker1askSize = new TextBox();
            txtTicker2askSize = new TextBox();
            txtCompraTicker1 = new TextBox();
            txtCompraTicker2 = new TextBox();
            txtDelta2a1 = new TextBox();
            txtDelta1a2 = new TextBox();
            btnRotar2a1 = new Button();
            btnRotar1a2 = new Button();
            chkAuto = new CheckBox();
            txtVentaTicker2 = new TextBox();
            txtVentaTicker1 = new TextBox();
            txtTicker2Bid = new TextBox();
            txtTicker1Bid = new TextBox();
            txtTicker2bidSize = new TextBox();
            txtTicker1bidSize = new TextBox();
            txtTenenciaTicker2 = new TextBox();
            txtTenenciaTicker1 = new TextBox();
            txtTicker2Last = new TextBox();
            txtTicker1Last = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            cboTicker2 = new ComboBox();
            cboTicker1 = new ComboBox();
            label1 = new Label();
            lstLog = new ListBox();
            groupBox3 = new GroupBox();
            txtToken = new TextBox();
            txtBearer = new TextBox();
            label16 = new Label();
            label15 = new Label();
            btnIngresar = new Button();
            label14 = new Label();
            txtClaveVETA = new TextBox();
            txtUsuarioVETA = new TextBox();
            txtClaveIOL = new TextBox();
            label13 = new Label();
            txtUsuarioIOL = new TextBox();
            label3 = new Label();
            label2 = new Label();
            crtGrafico = new ScottPlot.WinForms.FormsPlot();
            groupBox4 = new GroupBox();
            txtBandaInf = new TextBox();
            label21 = new Label();
            txtBandaSup = new TextBox();
            label20 = new Label();
            chkBandas = new CheckBox();
            cboPlazo = new ComboBox();
            label19 = new Label();
            chkAutoVol = new CheckBox();
            cboUmbral = new ComboBox();
            label18 = new Label();
            txtVolatilidad = new TextBox();
            label17 = new Label();
            tmrToken = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTicker1Ask);
            groupBox1.Controls.Add(txtTicker2Ask);
            groupBox1.Controls.Add(txtTicker1askSize);
            groupBox1.Controls.Add(txtTicker2askSize);
            groupBox1.Controls.Add(txtCompraTicker1);
            groupBox1.Controls.Add(txtCompraTicker2);
            groupBox1.Controls.Add(txtDelta2a1);
            groupBox1.Controls.Add(txtDelta1a2);
            groupBox1.Controls.Add(btnRotar2a1);
            groupBox1.Controls.Add(btnRotar1a2);
            groupBox1.Controls.Add(chkAuto);
            groupBox1.Controls.Add(txtVentaTicker2);
            groupBox1.Controls.Add(txtVentaTicker1);
            groupBox1.Controls.Add(txtTicker2Bid);
            groupBox1.Controls.Add(txtTicker1Bid);
            groupBox1.Controls.Add(txtTicker2bidSize);
            groupBox1.Controls.Add(txtTicker1bidSize);
            groupBox1.Controls.Add(txtTenenciaTicker2);
            groupBox1.Controls.Add(txtTenenciaTicker1);
            groupBox1.Controls.Add(txtTicker2Last);
            groupBox1.Controls.Add(txtTicker1Last);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboTicker2);
            groupBox1.Controls.Add(cboTicker1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 96);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Market Data";
            // 
            // txtTicker1Ask
            // 
            txtTicker1Ask.Location = new Point(280, 66);
            txtTicker1Ask.Name = "txtTicker1Ask";
            txtTicker1Ask.Size = new Size(39, 23);
            txtTicker1Ask.TabIndex = 33;
            // 
            // txtTicker2Ask
            // 
            txtTicker2Ask.Location = new Point(280, 37);
            txtTicker2Ask.Name = "txtTicker2Ask";
            txtTicker2Ask.Size = new Size(39, 23);
            txtTicker2Ask.TabIndex = 32;
            // 
            // txtTicker1askSize
            // 
            txtTicker1askSize.Location = new Point(326, 66);
            txtTicker1askSize.Name = "txtTicker1askSize";
            txtTicker1askSize.Size = new Size(47, 23);
            txtTicker1askSize.TabIndex = 31;
            // 
            // txtTicker2askSize
            // 
            txtTicker2askSize.Location = new Point(326, 37);
            txtTicker2askSize.Name = "txtTicker2askSize";
            txtTicker2askSize.Size = new Size(47, 23);
            txtTicker2askSize.TabIndex = 30;
            // 
            // txtCompraTicker1
            // 
            txtCompraTicker1.Location = new Point(379, 65);
            txtCompraTicker1.Name = "txtCompraTicker1";
            txtCompraTicker1.Size = new Size(47, 23);
            txtCompraTicker1.TabIndex = 29;
            // 
            // txtCompraTicker2
            // 
            txtCompraTicker2.Location = new Point(379, 37);
            txtCompraTicker2.Name = "txtCompraTicker2";
            txtCompraTicker2.Size = new Size(47, 23);
            txtCompraTicker2.TabIndex = 28;
            // 
            // txtDelta2a1
            // 
            txtDelta2a1.Location = new Point(432, 65);
            txtDelta2a1.Name = "txtDelta2a1";
            txtDelta2a1.Size = new Size(46, 23);
            txtDelta2a1.TabIndex = 27;
            // 
            // txtDelta1a2
            // 
            txtDelta1a2.Location = new Point(432, 37);
            txtDelta1a2.Name = "txtDelta1a2";
            txtDelta1a2.Size = new Size(46, 23);
            txtDelta1a2.TabIndex = 26;
            // 
            // btnRotar2a1
            // 
            btnRotar2a1.Location = new Point(484, 65);
            btnRotar2a1.Name = "btnRotar2a1";
            btnRotar2a1.Size = new Size(49, 23);
            btnRotar2a1.TabIndex = 25;
            btnRotar2a1.Text = "Rotar";
            btnRotar2a1.UseVisualStyleBackColor = true;
            // 
            // btnRotar1a2
            // 
            btnRotar1a2.Location = new Point(484, 37);
            btnRotar1a2.Name = "btnRotar1a2";
            btnRotar1a2.Size = new Size(49, 23);
            btnRotar1a2.TabIndex = 24;
            btnRotar1a2.Text = "Rotar";
            btnRotar1a2.UseVisualStyleBackColor = true;
            // 
            // chkAuto
            // 
            chkAuto.AutoSize = true;
            chkAuto.Location = new Point(484, 19);
            chkAuto.Name = "chkAuto";
            chkAuto.Size = new Size(52, 19);
            chkAuto.TabIndex = 23;
            chkAuto.Text = "Auto";
            chkAuto.UseVisualStyleBackColor = true;
            // 
            // txtVentaTicker2
            // 
            txtVentaTicker2.Location = new Point(235, 67);
            txtVentaTicker2.Name = "txtVentaTicker2";
            txtVentaTicker2.Size = new Size(39, 23);
            txtVentaTicker2.TabIndex = 22;
            // 
            // txtVentaTicker1
            // 
            txtVentaTicker1.Location = new Point(235, 37);
            txtVentaTicker1.Name = "txtVentaTicker1";
            txtVentaTicker1.Size = new Size(39, 23);
            txtVentaTicker1.TabIndex = 21;
            // 
            // txtTicker2Bid
            // 
            txtTicker2Bid.Location = new Point(190, 67);
            txtTicker2Bid.Name = "txtTicker2Bid";
            txtTicker2Bid.Size = new Size(39, 23);
            txtTicker2Bid.TabIndex = 20;
            // 
            // txtTicker1Bid
            // 
            txtTicker1Bid.Location = new Point(190, 37);
            txtTicker1Bid.Name = "txtTicker1Bid";
            txtTicker1Bid.Size = new Size(39, 23);
            txtTicker1Bid.TabIndex = 19;
            // 
            // txtTicker2bidSize
            // 
            txtTicker2bidSize.Location = new Point(145, 67);
            txtTicker2bidSize.Name = "txtTicker2bidSize";
            txtTicker2bidSize.Size = new Size(39, 23);
            txtTicker2bidSize.TabIndex = 18;
            // 
            // txtTicker1bidSize
            // 
            txtTicker1bidSize.Location = new Point(145, 37);
            txtTicker1bidSize.Name = "txtTicker1bidSize";
            txtTicker1bidSize.Size = new Size(39, 23);
            txtTicker1bidSize.TabIndex = 17;
            // 
            // txtTenenciaTicker2
            // 
            txtTenenciaTicker2.Location = new Point(100, 67);
            txtTenenciaTicker2.Name = "txtTenenciaTicker2";
            txtTenenciaTicker2.Size = new Size(39, 23);
            txtTenenciaTicker2.TabIndex = 16;
            // 
            // txtTenenciaTicker1
            // 
            txtTenenciaTicker1.Location = new Point(100, 37);
            txtTenenciaTicker1.Name = "txtTenenciaTicker1";
            txtTenenciaTicker1.Size = new Size(39, 23);
            txtTenenciaTicker1.TabIndex = 15;
            // 
            // txtTicker2Last
            // 
            txtTicker2Last.Location = new Point(55, 67);
            txtTicker2Last.Name = "txtTicker2Last";
            txtTicker2Last.Size = new Size(39, 23);
            txtTicker2Last.TabIndex = 14;
            // 
            // txtTicker1Last
            // 
            txtTicker1Last.Location = new Point(55, 37);
            txtTicker1Last.Name = "txtTicker1Last";
            txtTicker1Last.Size = new Size(39, 23);
            txtTicker1Last.TabIndex = 13;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(432, 19);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 12;
            label12.Text = "Δ media";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(376, 19);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 11;
            label11.Text = "Compra";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(326, 19);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 10;
            label10.Text = "askSize";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(280, 19);
            label9.Name = "label9";
            label9.Size = new Size(26, 15);
            label9.TabIndex = 9;
            label9.Text = "Ask";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(235, 19);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 8;
            label8.Text = "Venta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(195, 19);
            label7.Name = "label7";
            label7.Size = new Size(24, 15);
            label7.TabIndex = 7;
            label7.Text = "Bid";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(145, 19);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 6;
            label6.Text = "bidSize";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(89, 19);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 5;
            label5.Text = "Tenencia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 19);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 4;
            label4.Text = "Last";
            // 
            // cboTicker2
            // 
            cboTicker2.FormattingEnabled = true;
            cboTicker2.Location = new Point(6, 67);
            cboTicker2.Name = "cboTicker2";
            cboTicker2.Size = new Size(47, 23);
            cboTicker2.TabIndex = 3;
            // 
            // cboTicker1
            // 
            cboTicker1.FormattingEnabled = true;
            cboTicker1.Location = new Point(6, 37);
            cboTicker1.Name = "cboTicker1";
            cboTicker1.Size = new Size(47, 23);
            cboTicker1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Tickers";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(12, 470);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(542, 34);
            lstLog.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtToken);
            groupBox3.Controls.Add(txtBearer);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(btnIngresar);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(txtClaveVETA);
            groupBox3.Controls.Add(txtUsuarioVETA);
            groupBox3.Controls.Add(txtClaveIOL);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(txtUsuarioIOL);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(12, 336);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(542, 76);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Login";
            // 
            // txtToken
            // 
            txtToken.Location = new Point(456, 45);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(75, 23);
            txtToken.TabIndex = 12;
            // 
            // txtBearer
            // 
            txtBearer.Location = new Point(456, 16);
            txtBearer.Name = "txtBearer";
            txtBearer.Size = new Size(75, 23);
            txtBearer.TabIndex = 11;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(410, 48);
            label16.Name = "label16";
            label16.Size = new Size(38, 15);
            label16.TabIndex = 10;
            label16.Text = "Token";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(410, 19);
            label15.Name = "label15";
            label15.Size = new Size(40, 15);
            label15.TabIndex = 9;
            label15.Text = "Bearer";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(340, 16);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(64, 53);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(190, 48);
            label14.Name = "label14";
            label14.Size = new Size(36, 15);
            label14.TabIndex = 7;
            label14.Text = "Clave";
            // 
            // txtClaveVETA
            // 
            txtClaveVETA.Location = new Point(232, 45);
            txtClaveVETA.Name = "txtClaveVETA";
            txtClaveVETA.Size = new Size(100, 23);
            txtClaveVETA.TabIndex = 6;
            txtClaveVETA.UseSystemPasswordChar = true;
            // 
            // txtUsuarioVETA
            // 
            txtUsuarioVETA.Location = new Point(80, 45);
            txtUsuarioVETA.Name = "txtUsuarioVETA";
            txtUsuarioVETA.Size = new Size(100, 23);
            txtUsuarioVETA.TabIndex = 5;
            // 
            // txtClaveIOL
            // 
            txtClaveIOL.Location = new Point(232, 16);
            txtClaveIOL.Name = "txtClaveIOL";
            txtClaveIOL.Size = new Size(100, 23);
            txtClaveIOL.TabIndex = 4;
            txtClaveIOL.UseSystemPasswordChar = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(190, 19);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 3;
            label13.Text = "Clave";
            // 
            // txtUsuarioIOL
            // 
            txtUsuarioIOL.Location = new Point(80, 16);
            txtUsuarioIOL.Name = "txtUsuarioIOL";
            txtUsuarioIOL.Size = new Size(100, 23);
            txtUsuarioIOL.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 48);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 1;
            label3.Text = "Veta Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 0;
            label2.Text = "IOL Usuario";
            // 
            // crtGrafico
            // 
            crtGrafico.DisplayScale = 1F;
            crtGrafico.Location = new Point(12, 114);
            crtGrafico.Name = "crtGrafico";
            crtGrafico.Size = new Size(547, 219);
            crtGrafico.TabIndex = 4;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtBandaInf);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(txtBandaSup);
            groupBox4.Controls.Add(label20);
            groupBox4.Controls.Add(chkBandas);
            groupBox4.Controls.Add(cboPlazo);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(chkAutoVol);
            groupBox4.Controls.Add(cboUmbral);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(txtVolatilidad);
            groupBox4.Controls.Add(label17);
            groupBox4.Location = new Point(12, 418);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(542, 46);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Parámetros";
            // 
            // txtBandaInf
            // 
            txtBandaInf.Location = new Point(500, 17);
            txtBandaInf.Name = "txtBandaInf";
            txtBandaInf.Size = new Size(31, 23);
            txtBandaInf.TabIndex = 31;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(473, 19);
            label21.Name = "label21";
            label21.Size = new Size(21, 15);
            label21.TabIndex = 30;
            label21.Text = "Inf";
            // 
            // txtBandaSup
            // 
            txtBandaSup.Location = new Point(436, 17);
            txtBandaSup.Name = "txtBandaSup";
            txtBandaSup.Size = new Size(31, 23);
            txtBandaSup.TabIndex = 29;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(408, 19);
            label20.Name = "label20";
            label20.Size = new Size(27, 15);
            label20.TabIndex = 28;
            label20.Text = "Sup";
            // 
            // chkBandas
            // 
            chkBandas.AutoSize = true;
            chkBandas.CheckAlign = ContentAlignment.MiddleRight;
            chkBandas.Location = new Point(338, 18);
            chkBandas.Name = "chkBandas";
            chkBandas.Size = new Size(64, 19);
            chkBandas.TabIndex = 27;
            chkBandas.Text = "Bandas";
            chkBandas.UseVisualStyleBackColor = true;
            // 
            // cboPlazo
            // 
            cboPlazo.FormattingEnabled = true;
            cboPlazo.Location = new Point(293, 16);
            cboPlazo.Name = "cboPlazo";
            cboPlazo.Size = new Size(39, 23);
            cboPlazo.TabIndex = 26;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(258, 19);
            label19.Name = "label19";
            label19.Size = new Size(35, 15);
            label19.TabIndex = 25;
            label19.Text = "Plazo";
            // 
            // chkAutoVol
            // 
            chkAutoVol.AutoSize = true;
            chkAutoVol.Location = new Point(204, 18);
            chkAutoVol.Name = "chkAutoVol";
            chkAutoVol.Size = new Size(52, 19);
            chkAutoVol.TabIndex = 24;
            chkAutoVol.Text = "Auto";
            chkAutoVol.UseVisualStyleBackColor = true;
            // 
            // cboUmbral
            // 
            cboUmbral.FormattingEnabled = true;
            cboUmbral.Location = new Point(155, 16);
            cboUmbral.Name = "cboUmbral";
            cboUmbral.Size = new Size(43, 23);
            cboUmbral.TabIndex = 14;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(107, 19);
            label18.Name = "label18";
            label18.Size = new Size(46, 15);
            label18.TabIndex = 13;
            label18.Text = "Umbral";
            // 
            // txtVolatilidad
            // 
            txtVolatilidad.Location = new Point(69, 16);
            txtVolatilidad.Name = "txtVolatilidad";
            txtVolatilidad.Size = new Size(34, 23);
            txtVolatilidad.TabIndex = 12;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 19);
            label17.Name = "label17";
            label17.Size = new Size(62, 15);
            label17.TabIndex = 1;
            label17.Text = "Volatilidad";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 512);
            Controls.Add(groupBox4);
            Controls.Add(crtGrafico);
            Controls.Add(groupBox3);
            Controls.Add(lstLog);
            Controls.Add(groupBox1);
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private GroupBox groupBox1;
        private ComboBox cboTicker1;
        private Label label1;
        private ComboBox cboTicker2;
        private ListBox lstLog;
        private GroupBox groupBox3;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtTicker2Last;
        private TextBox txtTicker1Last;
        private TextBox txtTenenciaTicker2;
        private TextBox txtTenenciaTicker1;
        private TextBox txtTicker2bidSize;
        private TextBox txtTicker1bidSize;
        private TextBox txtVentaTicker2;
        private TextBox txtVentaTicker1;
        private TextBox txtTicker2Bid;
        private TextBox txtTicker1Bid;
        private TextBox txtDelta2a1;
        private TextBox txtDelta1a2;
        private Button btnRotar2a1;
        private Button btnRotar1a2;
        private CheckBox chkAuto;
        private TextBox txtCompraTicker1;
        private TextBox txtCompraTicker2;
        private TextBox txtTicker1askSize;
        private TextBox txtTicker2askSize;
        private TextBox txtTicker2Ask;
        private TextBox txtTicker1Ask;
        private ScottPlot.WinForms.FormsPlot crtGrafico;
        private TextBox txtUsuarioIOL;
        private Label label13;
        private Label label14;
        private TextBox txtClaveVETA;
        private TextBox txtUsuarioVETA;
        private TextBox txtClaveIOL;
        private Label label16;
        private Label label15;
        private Button btnIngresar;
        private TextBox txtToken;
        private TextBox txtBearer;
        private GroupBox groupBox4;
        private CheckBox chkAutoVol;
        private ComboBox cboUmbral;
        private Label label18;
        private TextBox txtVolatilidad;
        private Label label17;
        private Label label20;
        private CheckBox chkBandas;
        private ComboBox cboPlazo;
        private Label label19;
        private TextBox txtBandaInf;
        private Label label21;
        private TextBox txtBandaSup;
        private System.Windows.Forms.Timer tmrToken;
    }
}
