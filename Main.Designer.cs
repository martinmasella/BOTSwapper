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
            cboTicker1 = new ComboBox();
            label1 = new Label();
            cboTicker2 = new ComboBox();
            lstLog = new ListBox();
            groupBox2 = new GroupBox();
            txtStatus = new TextBox();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            // cboTicker1
            // 
            cboTicker1.FormattingEnabled = true;
            cboTicker1.Location = new Point(6, 37);
            cboTicker1.Name = "cboTicker1";
            cboTicker1.Size = new Size(43, 23);
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
            // cboTicker2
            // 
            cboTicker2.FormattingEnabled = true;
            cboTicker2.Location = new Point(6, 67);
            cboTicker2.Name = "cboTicker2";
            cboTicker2.Size = new Size(43, 23);
            cboTicker2.TabIndex = 3;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(12, 470);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(434, 34);
            lstLog.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtStatus);
            groupBox2.Location = new Point(459, 453);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(95, 51);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Status";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(9, 17);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(80, 23);
            txtStatus.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(12, 394);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(542, 53);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "grpLogin";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 512);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lstLog);
            Controls.Add(groupBox1);
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private GroupBox groupBox1;
        private ComboBox cboTicker1;
        private Label label1;
        private ComboBox cboTicker2;
        private ListBox lstLog;
        private GroupBox groupBox2;
        private TextBox txtStatus;
        private GroupBox groupBox3;
    }
}
