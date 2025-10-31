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
			label22 = new Label();
			txtMM = new TextBox();
			label23 = new Label();
			txt1a2 = new TextBox();
			txtLastData = new TextBox();
			txt2a1 = new TextBox();
			label25 = new Label();
			label26 = new Label();
			txtMax = new TextBox();
			label27 = new Label();
			txtRatio = new TextBox();
			label28 = new Label();
			txtMin = new TextBox();
			label29 = new Label();
			txtDesvios = new TextBox();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// tmrRefresh
			// 
			tmrRefresh.Tick += tmrRefresh_Tick;
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
			groupBox1.Location = new Point(17, 20);
			groupBox1.Margin = new Padding(4, 5, 4, 5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 5, 4, 5);
			groupBox1.Size = new Size(774, 160);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Market Data";
			// 
			// txtTicker1Ask
			// 
			txtTicker1Ask.Location = new Point(414, 112);
			txtTicker1Ask.Margin = new Padding(4, 5, 4, 5);
			txtTicker1Ask.Name = "txtTicker1Ask";
			txtTicker1Ask.Size = new Size(68, 31);
			txtTicker1Ask.TabIndex = 33;
			// 
			// txtTicker2Ask
			// 
			txtTicker2Ask.Location = new Point(414, 62);
			txtTicker2Ask.Margin = new Padding(4, 5, 4, 5);
			txtTicker2Ask.Name = "txtTicker2Ask";
			txtTicker2Ask.Size = new Size(68, 31);
			txtTicker2Ask.TabIndex = 32;
			// 
			// txtTicker1askSize
			// 
			txtTicker1askSize.Location = new Point(483, 112);
			txtTicker1askSize.Margin = new Padding(4, 5, 4, 5);
			txtTicker1askSize.Name = "txtTicker1askSize";
			txtTicker1askSize.Size = new Size(65, 31);
			txtTicker1askSize.TabIndex = 31;
			// 
			// txtTicker2askSize
			// 
			txtTicker2askSize.Location = new Point(483, 62);
			txtTicker2askSize.Margin = new Padding(4, 5, 4, 5);
			txtTicker2askSize.Name = "txtTicker2askSize";
			txtTicker2askSize.Size = new Size(65, 31);
			txtTicker2askSize.TabIndex = 30;
			// 
			// txtCompraTicker1
			// 
			txtCompraTicker1.Location = new Point(549, 112);
			txtCompraTicker1.Margin = new Padding(4, 5, 4, 5);
			txtCompraTicker1.Name = "txtCompraTicker1";
			txtCompraTicker1.Size = new Size(77, 31);
			txtCompraTicker1.TabIndex = 29;
			// 
			// txtCompraTicker2
			// 
			txtCompraTicker2.Location = new Point(549, 62);
			txtCompraTicker2.Margin = new Padding(4, 5, 4, 5);
			txtCompraTicker2.Name = "txtCompraTicker2";
			txtCompraTicker2.Size = new Size(77, 31);
			txtCompraTicker2.TabIndex = 28;
			// 
			// txtDelta2a1
			// 
			txtDelta2a1.Location = new Point(629, 112);
			txtDelta2a1.Margin = new Padding(4, 5, 4, 5);
			txtDelta2a1.Name = "txtDelta2a1";
			txtDelta2a1.Size = new Size(61, 31);
			txtDelta2a1.TabIndex = 27;
			// 
			// txtDelta1a2
			// 
			txtDelta1a2.Location = new Point(629, 62);
			txtDelta1a2.Margin = new Padding(4, 5, 4, 5);
			txtDelta1a2.Name = "txtDelta1a2";
			txtDelta1a2.Size = new Size(61, 31);
			txtDelta1a2.TabIndex = 26;
			// 
			// btnRotar2a1
			// 
			btnRotar2a1.Location = new Point(691, 108);
			btnRotar2a1.Margin = new Padding(4, 5, 4, 5);
			btnRotar2a1.Name = "btnRotar2a1";
			btnRotar2a1.Size = new Size(70, 38);
			btnRotar2a1.TabIndex = 25;
			btnRotar2a1.Text = "Rotar";
			btnRotar2a1.UseVisualStyleBackColor = true;
			btnRotar2a1.Click += btnRotar2a1_Click;
			// 
			// btnRotar1a2
			// 
			btnRotar1a2.Location = new Point(691, 62);
			btnRotar1a2.Margin = new Padding(4, 5, 4, 5);
			btnRotar1a2.Name = "btnRotar1a2";
			btnRotar1a2.Size = new Size(70, 38);
			btnRotar1a2.TabIndex = 24;
			btnRotar1a2.Text = "Rotar";
			btnRotar1a2.UseVisualStyleBackColor = true;
			btnRotar1a2.Click += btnRotar1a2_Click;
			// 
			// chkAuto
			// 
			chkAuto.AutoSize = true;
			chkAuto.Location = new Point(697, 32);
			chkAuto.Margin = new Padding(4, 5, 4, 5);
			chkAuto.Name = "chkAuto";
			chkAuto.Size = new Size(77, 29);
			chkAuto.TabIndex = 23;
			chkAuto.Text = "Auto";
			chkAuto.UseVisualStyleBackColor = true;
			// 
			// txtVentaTicker2
			// 
			txtVentaTicker2.Location = new Point(348, 112);
			txtVentaTicker2.Margin = new Padding(4, 5, 4, 5);
			txtVentaTicker2.Name = "txtVentaTicker2";
			txtVentaTicker2.Size = new Size(65, 31);
			txtVentaTicker2.TabIndex = 22;
			// 
			// txtVentaTicker1
			// 
			txtVentaTicker1.Location = new Point(348, 62);
			txtVentaTicker1.Margin = new Padding(4, 5, 4, 5);
			txtVentaTicker1.Name = "txtVentaTicker1";
			txtVentaTicker1.Size = new Size(65, 31);
			txtVentaTicker1.TabIndex = 21;
			// 
			// txtTicker2Bid
			// 
			txtTicker2Bid.Location = new Point(276, 112);
			txtTicker2Bid.Margin = new Padding(4, 5, 4, 5);
			txtTicker2Bid.Name = "txtTicker2Bid";
			txtTicker2Bid.Size = new Size(71, 31);
			txtTicker2Bid.TabIndex = 20;
			// 
			// txtTicker1Bid
			// 
			txtTicker1Bid.Location = new Point(276, 62);
			txtTicker1Bid.Margin = new Padding(4, 5, 4, 5);
			txtTicker1Bid.Name = "txtTicker1Bid";
			txtTicker1Bid.Size = new Size(71, 31);
			txtTicker1Bid.TabIndex = 19;
			// 
			// txtTicker2bidSize
			// 
			txtTicker2bidSize.Location = new Point(214, 112);
			txtTicker2bidSize.Margin = new Padding(4, 5, 4, 5);
			txtTicker2bidSize.Name = "txtTicker2bidSize";
			txtTicker2bidSize.Size = new Size(60, 31);
			txtTicker2bidSize.TabIndex = 18;
			// 
			// txtTicker1bidSize
			// 
			txtTicker1bidSize.Location = new Point(214, 62);
			txtTicker1bidSize.Margin = new Padding(4, 5, 4, 5);
			txtTicker1bidSize.Name = "txtTicker1bidSize";
			txtTicker1bidSize.Size = new Size(60, 31);
			txtTicker1bidSize.TabIndex = 17;
			// 
			// txtTenenciaTicker2
			// 
			txtTenenciaTicker2.Location = new Point(155, 112);
			txtTenenciaTicker2.Margin = new Padding(4, 5, 4, 5);
			txtTenenciaTicker2.Name = "txtTenenciaTicker2";
			txtTenenciaTicker2.Size = new Size(57, 31);
			txtTenenciaTicker2.TabIndex = 16;
			// 
			// txtTenenciaTicker1
			// 
			txtTenenciaTicker1.Location = new Point(155, 62);
			txtTenenciaTicker1.Margin = new Padding(4, 5, 4, 5);
			txtTenenciaTicker1.Name = "txtTenenciaTicker1";
			txtTenenciaTicker1.Size = new Size(57, 31);
			txtTenenciaTicker1.TabIndex = 15;
			// 
			// txtTicker2Last
			// 
			txtTicker2Last.Location = new Point(87, 112);
			txtTicker2Last.Margin = new Padding(4, 5, 4, 5);
			txtTicker2Last.Name = "txtTicker2Last";
			txtTicker2Last.Size = new Size(67, 31);
			txtTicker2Last.TabIndex = 14;
			// 
			// txtTicker1Last
			// 
			txtTicker1Last.Location = new Point(87, 62);
			txtTicker1Last.Margin = new Padding(4, 5, 4, 5);
			txtTicker1Last.Name = "txtTicker1Last";
			txtTicker1Last.Size = new Size(67, 31);
			txtTicker1Last.TabIndex = 13;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(620, 32);
			label12.Margin = new Padding(4, 0, 4, 0);
			label12.Name = "label12";
			label12.Size = new Size(78, 25);
			label12.TabIndex = 12;
			label12.Text = "Δ media";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(545, 32);
			label11.Margin = new Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new Size(76, 25);
			label11.TabIndex = 11;
			label11.Text = "Compra";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(483, 32);
			label10.Margin = new Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new Size(69, 25);
			label10.TabIndex = 10;
			label10.Text = "askSize";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(418, 32);
			label9.Margin = new Padding(4, 0, 4, 0);
			label9.Name = "label9";
			label9.Size = new Size(41, 25);
			label9.TabIndex = 9;
			label9.Text = "Ask";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(348, 32);
			label8.Margin = new Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new Size(56, 25);
			label8.TabIndex = 8;
			label8.Text = "Venta";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(281, 32);
			label7.Margin = new Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new Size(37, 25);
			label7.TabIndex = 7;
			label7.Text = "Bid";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(213, 32);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(69, 25);
			label6.TabIndex = 6;
			label6.Text = "bidSize";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(143, 32);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(78, 25);
			label5.TabIndex = 5;
			label5.Text = "Tenencia";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(84, 32);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(43, 25);
			label4.TabIndex = 4;
			label4.Text = "Last";
			// 
			// cboTicker2
			// 
			cboTicker2.FormattingEnabled = true;
			cboTicker2.Location = new Point(9, 112);
			cboTicker2.Margin = new Padding(4, 5, 4, 5);
			cboTicker2.Name = "cboTicker2";
			cboTicker2.Size = new Size(75, 33);
			cboTicker2.TabIndex = 3;
			// 
			// cboTicker1
			// 
			cboTicker1.FormattingEnabled = true;
			cboTicker1.Location = new Point(9, 62);
			cboTicker1.Margin = new Padding(4, 5, 4, 5);
			cboTicker1.Name = "cboTicker1";
			cboTicker1.Size = new Size(75, 33);
			cboTicker1.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 32);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(65, 25);
			label1.TabIndex = 1;
			label1.Text = "Tickers";
			// 
			// lstLog
			// 
			lstLog.FormattingEnabled = true;
			lstLog.ItemHeight = 25;
			lstLog.Location = new Point(17, 733);
			lstLog.Margin = new Padding(4, 5, 4, 5);
			lstLog.Name = "lstLog";
			lstLog.Size = new Size(773, 104);
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
			groupBox3.Location = new Point(17, 523);
			groupBox3.Margin = new Padding(4, 5, 4, 5);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(4, 5, 4, 5);
			groupBox3.Size = new Size(774, 127);
			groupBox3.TabIndex = 3;
			groupBox3.TabStop = false;
			groupBox3.Text = "Login";
			// 
			// txtToken
			// 
			txtToken.Location = new Point(651, 75);
			txtToken.Margin = new Padding(4, 5, 4, 5);
			txtToken.Name = "txtToken";
			txtToken.Size = new Size(105, 31);
			txtToken.TabIndex = 12;
			// 
			// txtBearer
			// 
			txtBearer.Location = new Point(651, 27);
			txtBearer.Margin = new Padding(4, 5, 4, 5);
			txtBearer.Name = "txtBearer";
			txtBearer.Size = new Size(105, 31);
			txtBearer.TabIndex = 11;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(586, 80);
			label16.Margin = new Padding(4, 0, 4, 0);
			label16.Name = "label16";
			label16.Size = new Size(58, 25);
			label16.TabIndex = 10;
			label16.Text = "Token";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(586, 32);
			label15.Margin = new Padding(4, 0, 4, 0);
			label15.Name = "label15";
			label15.Size = new Size(61, 25);
			label15.TabIndex = 9;
			label15.Text = "Bearer";
			// 
			// btnIngresar
			// 
			btnIngresar.Location = new Point(486, 27);
			btnIngresar.Margin = new Padding(4, 5, 4, 5);
			btnIngresar.Name = "btnIngresar";
			btnIngresar.Size = new Size(91, 88);
			btnIngresar.TabIndex = 8;
			btnIngresar.Text = "Ingresar";
			btnIngresar.UseVisualStyleBackColor = true;
			btnIngresar.Click += btnIngresar_Click;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(271, 80);
			label14.Margin = new Padding(4, 0, 4, 0);
			label14.Name = "label14";
			label14.Size = new Size(54, 25);
			label14.TabIndex = 7;
			label14.Text = "Clave";
			// 
			// txtClaveVETA
			// 
			txtClaveVETA.Location = new Point(331, 75);
			txtClaveVETA.Margin = new Padding(4, 5, 4, 5);
			txtClaveVETA.Name = "txtClaveVETA";
			txtClaveVETA.Size = new Size(141, 31);
			txtClaveVETA.TabIndex = 6;
			txtClaveVETA.UseSystemPasswordChar = true;
			// 
			// txtUsuarioVETA
			// 
			txtUsuarioVETA.Location = new Point(114, 75);
			txtUsuarioVETA.Margin = new Padding(4, 5, 4, 5);
			txtUsuarioVETA.Name = "txtUsuarioVETA";
			txtUsuarioVETA.Size = new Size(141, 31);
			txtUsuarioVETA.TabIndex = 5;
			// 
			// txtClaveIOL
			// 
			txtClaveIOL.Location = new Point(331, 27);
			txtClaveIOL.Margin = new Padding(4, 5, 4, 5);
			txtClaveIOL.Name = "txtClaveIOL";
			txtClaveIOL.Size = new Size(141, 31);
			txtClaveIOL.TabIndex = 4;
			txtClaveIOL.UseSystemPasswordChar = true;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(271, 32);
			label13.Margin = new Padding(4, 0, 4, 0);
			label13.Name = "label13";
			label13.Size = new Size(54, 25);
			label13.TabIndex = 3;
			label13.Text = "Clave";
			// 
			// txtUsuarioIOL
			// 
			txtUsuarioIOL.Location = new Point(114, 27);
			txtUsuarioIOL.Margin = new Padding(4, 5, 4, 5);
			txtUsuarioIOL.Name = "txtUsuarioIOL";
			txtUsuarioIOL.Size = new Size(141, 31);
			txtUsuarioIOL.TabIndex = 2;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(9, 80);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(111, 25);
			label3.TabIndex = 1;
			label3.Text = "Veta Usuario";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(9, 32);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(104, 25);
			label2.TabIndex = 0;
			label2.Text = "IOL Usuario";
			// 
			// crtGrafico
			// 
			crtGrafico.DisplayScale = 1F;
			crtGrafico.Location = new Point(116, 190);
			crtGrafico.Margin = new Padding(4, 5, 4, 5);
			crtGrafico.Name = "crtGrafico";
			crtGrafico.Size = new Size(677, 350);
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
			groupBox4.Location = new Point(17, 660);
			groupBox4.Margin = new Padding(4, 5, 4, 5);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(4, 5, 4, 5);
			groupBox4.Size = new Size(774, 77);
			groupBox4.TabIndex = 5;
			groupBox4.TabStop = false;
			groupBox4.Text = "Parámetros";
			// 
			// txtBandaInf
			// 
			txtBandaInf.Location = new Point(714, 28);
			txtBandaInf.Margin = new Padding(4, 5, 4, 5);
			txtBandaInf.Name = "txtBandaInf";
			txtBandaInf.Size = new Size(43, 31);
			txtBandaInf.TabIndex = 31;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new Point(676, 32);
			label21.Margin = new Padding(4, 0, 4, 0);
			label21.Name = "label21";
			label21.Size = new Size(33, 25);
			label21.TabIndex = 30;
			label21.Text = "Inf";
			// 
			// txtBandaSup
			// 
			txtBandaSup.Location = new Point(623, 28);
			txtBandaSup.Margin = new Padding(4, 5, 4, 5);
			txtBandaSup.Name = "txtBandaSup";
			txtBandaSup.Size = new Size(43, 31);
			txtBandaSup.TabIndex = 29;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new Point(583, 32);
			label20.Margin = new Padding(4, 0, 4, 0);
			label20.Name = "label20";
			label20.Size = new Size(43, 25);
			label20.TabIndex = 28;
			label20.Text = "Sup";
			// 
			// chkBandas
			// 
			chkBandas.AutoSize = true;
			chkBandas.CheckAlign = ContentAlignment.MiddleRight;
			chkBandas.Location = new Point(434, 30);
			chkBandas.Margin = new Padding(4, 5, 4, 5);
			chkBandas.Name = "chkBandas";
			chkBandas.Size = new Size(150, 29);
			chkBandas.TabIndex = 27;
			chkBandas.Text = "Forzar bandas";
			chkBandas.UseVisualStyleBackColor = true;
			// 
			// cboPlazo
			// 
			cboPlazo.FormattingEnabled = true;
			cboPlazo.Location = new Point(356, 27);
			cboPlazo.Margin = new Padding(4, 5, 4, 5);
			cboPlazo.Name = "cboPlazo";
			cboPlazo.Size = new Size(54, 33);
			cboPlazo.TabIndex = 26;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(306, 32);
			label19.Margin = new Padding(4, 0, 4, 0);
			label19.Name = "label19";
			label19.Size = new Size(54, 25);
			label19.TabIndex = 25;
			label19.Text = "Plazo";
			// 
			// chkAutoVol
			// 
			chkAutoVol.AutoSize = true;
			chkAutoVol.Location = new Point(214, 32);
			chkAutoVol.Margin = new Padding(4, 5, 4, 5);
			chkAutoVol.Name = "chkAutoVol";
			chkAutoVol.Size = new Size(77, 29);
			chkAutoVol.TabIndex = 24;
			chkAutoVol.Text = "Auto";
			chkAutoVol.UseVisualStyleBackColor = true;
			// 
			// cboUmbral
			// 
			cboUmbral.FormattingEnabled = true;
			cboUmbral.Location = new Point(142, 27);
			cboUmbral.Margin = new Padding(4, 5, 4, 5);
			cboUmbral.Name = "cboUmbral";
			cboUmbral.Size = new Size(65, 33);
			cboUmbral.TabIndex = 14;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(9, 32);
			label18.Margin = new Padding(4, 0, 4, 0);
			label18.Name = "label18";
			label18.Size = new Size(141, 25);
			label18.TabIndex = 13;
			label18.Text = "Umbral Δ media";
			// 
			// txtVolatilidad
			// 
			txtVolatilidad.Location = new Point(74, 415);
			txtVolatilidad.Margin = new Padding(4, 5, 4, 5);
			txtVolatilidad.Name = "txtVolatilidad";
			txtVolatilidad.Size = new Size(51, 31);
			txtVolatilidad.TabIndex = 12;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(20, 420);
			label17.Margin = new Padding(4, 0, 4, 0);
			label17.Name = "label17";
			label17.Size = new Size(56, 25);
			label17.TabIndex = 1;
			label17.Text = "Volat.";
			// 
			// tmrToken
			// 
			tmrToken.Tick += tmrToken_Tick;
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new Point(17, 267);
			label22.Margin = new Padding(4, 0, 4, 0);
			label22.Name = "label22";
			label22.Size = new Size(44, 25);
			label22.TabIndex = 6;
			label22.Text = "MM";
			// 
			// txtMM
			// 
			txtMM.Location = new Point(74, 262);
			txtMM.Margin = new Padding(4, 5, 4, 5);
			txtMM.Name = "txtMM";
			txtMM.Size = new Size(51, 31);
			txtMM.TabIndex = 7;
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.Location = new Point(17, 228);
			label23.Margin = new Padding(4, 0, 4, 0);
			label23.Name = "label23";
			label23.Size = new Size(51, 25);
			label23.TabIndex = 8;
			label23.Text = "1->2";
			// 
			// txt1a2
			// 
			txt1a2.Location = new Point(74, 223);
			txt1a2.Margin = new Padding(4, 5, 4, 5);
			txt1a2.Name = "txt1a2";
			txt1a2.Size = new Size(51, 31);
			txt1a2.TabIndex = 9;
			// 
			// txtLastData
			// 
			txtLastData.Location = new Point(700, 467);
			txtLastData.Margin = new Padding(4, 5, 4, 5);
			txtLastData.Name = "txtLastData";
			txtLastData.Size = new Size(71, 31);
			txtLastData.TabIndex = 11;
			// 
			// txt2a1
			// 
			txt2a1.Location = new Point(74, 338);
			txt2a1.Margin = new Padding(4, 5, 4, 5);
			txt2a1.Name = "txt2a1";
			txt2a1.Size = new Size(51, 31);
			txt2a1.TabIndex = 12;
			// 
			// label25
			// 
			label25.AutoSize = true;
			label25.Location = new Point(20, 343);
			label25.Margin = new Padding(4, 0, 4, 0);
			label25.Name = "label25";
			label25.Size = new Size(51, 25);
			label25.TabIndex = 13;
			label25.Text = "2->1";
			// 
			// label26
			// 
			label26.AutoSize = true;
			label26.Location = new Point(17, 193);
			label26.Margin = new Padding(4, 0, 4, 0);
			label26.Name = "label26";
			label26.Size = new Size(45, 25);
			label26.TabIndex = 14;
			label26.Text = "Max";
			// 
			// txtMax
			// 
			txtMax.Location = new Point(74, 188);
			txtMax.Margin = new Padding(4, 5, 4, 5);
			txtMax.Name = "txtMax";
			txtMax.Size = new Size(51, 31);
			txtMax.TabIndex = 15;
			// 
			// label27
			// 
			label27.AutoSize = true;
			label27.Location = new Point(19, 305);
			label27.Margin = new Padding(4, 0, 4, 0);
			label27.Name = "label27";
			label27.Size = new Size(53, 25);
			label27.TabIndex = 16;
			label27.Text = "Ratio";
			// 
			// txtRatio
			// 
			txtRatio.Location = new Point(74, 300);
			txtRatio.Margin = new Padding(4, 5, 4, 5);
			txtRatio.Name = "txtRatio";
			txtRatio.Size = new Size(51, 31);
			txtRatio.TabIndex = 17;
			// 
			// label28
			// 
			label28.AutoSize = true;
			label28.Location = new Point(20, 382);
			label28.Margin = new Padding(4, 0, 4, 0);
			label28.Name = "label28";
			label28.Size = new Size(42, 25);
			label28.TabIndex = 18;
			label28.Text = "Min";
			// 
			// txtMin
			// 
			txtMin.Location = new Point(74, 377);
			txtMin.Margin = new Padding(4, 5, 4, 5);
			txtMin.Name = "txtMin";
			txtMin.Size = new Size(51, 31);
			txtMin.TabIndex = 19;
			// 
			// label29
			// 
			label29.AutoSize = true;
			label29.Location = new Point(19, 458);
			label29.Margin = new Padding(4, 0, 4, 0);
			label29.Name = "label29";
			label29.Size = new Size(55, 25);
			label29.TabIndex = 20;
			label29.Text = "Desv.";
			// 
			// txtDesvios
			// 
			txtDesvios.Location = new Point(74, 453);
			txtDesvios.Margin = new Padding(4, 5, 4, 5);
			txtDesvios.Name = "txtDesvios";
			txtDesvios.Size = new Size(51, 31);
			txtDesvios.TabIndex = 21;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(809, 853);
			Controls.Add(txtDesvios);
			Controls.Add(label29);
			Controls.Add(txtMin);
			Controls.Add(label28);
			Controls.Add(txtRatio);
			Controls.Add(label27);
			Controls.Add(txtMax);
			Controls.Add(label26);
			Controls.Add(label25);
			Controls.Add(txt2a1);
			Controls.Add(txtLastData);
			Controls.Add(label17);
			Controls.Add(txtVolatilidad);
			Controls.Add(txt1a2);
			Controls.Add(label23);
			Controls.Add(txtMM);
			Controls.Add(label22);
			Controls.Add(groupBox4);
			Controls.Add(crtGrafico);
			Controls.Add(groupBox3);
			Controls.Add(lstLog);
			Controls.Add(groupBox1);
			Margin = new Padding(4, 5, 4, 5);
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
			PerformLayout();
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
        private Label label22;
        private TextBox txtMM;
        private Label label23;
        private TextBox txt1a2;
        private TextBox txtLastData;
        private TextBox txt2a1;
        private Label label25;
        private Label label26;
        private TextBox txtMax;
        private Label label27;
        private TextBox txtRatio;
        private Label label28;
        private TextBox txtMin;
        private Label label29;
        private TextBox txtDesvios;
    }
}
