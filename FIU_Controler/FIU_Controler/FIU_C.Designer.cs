namespace FIU_Controler
{
    partial class FIU_C
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIU_C));
            this.label1 = new System.Windows.Forms.Label();
            this.DeIn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Baud = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Timer1label = new System.Windows.Forms.Label();
            this.Timer0 = new System.Windows.Forms.TextBox();
            this.Timer1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Default = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.StartDe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DeviceT = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Index";
            // 
            // DeIn
            // 
            this.DeIn.DisplayMember = "0";
            this.DeIn.FormattingEnabled = true;
            this.DeIn.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.DeIn.Location = new System.Drawing.Point(154, 91);
            this.DeIn.Name = "DeIn";
            this.DeIn.Size = new System.Drawing.Size(128, 26);
            this.DeIn.TabIndex = 1;
            this.DeIn.ValueMember = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel";
            // 
            // Ch
            // 
            this.Ch.FormattingEnabled = true;
            this.Ch.Items.AddRange(new object[] {
            "0",
            "1"});
            this.Ch.Location = new System.Drawing.Point(154, 139);
            this.Ch.Name = "Ch";
            this.Ch.Size = new System.Drawing.Size(128, 26);
            this.Ch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Baud Rate(kbps)";
            // 
            // Baud
            // 
            this.Baud.FormattingEnabled = true;
            this.Baud.Items.AddRange(new object[] {
            "1000",
            "800",
            "500",
            "250",
            "125",
            "100",
            "50",
            "20",
            "10",
            "5"});
            this.Baud.Location = new System.Drawing.Point(162, 49);
            this.Baud.Name = "Baud";
            this.Baud.Size = new System.Drawing.Size(108, 26);
            this.Baud.TabIndex = 4;
            this.Baud.SelectedIndexChanged += new System.EventHandler(this.Baud_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(214, 22);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "User define baudrate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Timer0(BTR0):0x";
            // 
            // Timer1label
            // 
            this.Timer1label.AutoSize = true;
            this.Timer1label.Location = new System.Drawing.Point(14, 175);
            this.Timer1label.Name = "Timer1label";
            this.Timer1label.Size = new System.Drawing.Size(143, 18);
            this.Timer1label.TabIndex = 6;
            this.Timer1label.Text = "Timer1(BTR1):0x";
            // 
            // Timer0
            // 
            this.Timer0.Location = new System.Drawing.Point(162, 140);
            this.Timer0.Name = "Timer0";
            this.Timer0.Size = new System.Drawing.Size(104, 28);
            this.Timer0.TabIndex = 7;
            // 
            // Timer1
            // 
            this.Timer1.Location = new System.Drawing.Point(162, 175);
            this.Timer1.Name = "Timer1";
            this.Timer1.Size = new System.Drawing.Size(104, 28);
            this.Timer1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Timer1);
            this.groupBox1.Controls.Add(this.Timer0);
            this.groupBox1.Controls.Add(this.Timer1label);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Baud);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(419, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 218);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // Default
            // 
            this.Default.Location = new System.Drawing.Point(193, 244);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(96, 37);
            this.Default.TabIndex = 9;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // Exit
            // 
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.Location = new System.Drawing.Point(558, 244);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(96, 37);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // StartDe
            // 
            this.StartDe.Location = new System.Drawing.Point(289, 310);
            this.StartDe.Name = "StartDe";
            this.StartDe.Size = new System.Drawing.Size(259, 36);
            this.StartDe.TabIndex = 9;
            this.StartDe.Text = "StartDeviece";
            this.StartDe.UseVisualStyleBackColor = true;
            this.StartDe.Click += new System.EventHandler(this.StartDe_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Device Type";
            // 
            // DeviceT
            // 
            this.DeviceT.DisplayMember = "0";
            this.DeviceT.FormattingEnabled = true;
            this.DeviceT.Items.AddRange(new object[] {
            "PCI5121 ",
            "PCI9810 ",
            "USBCAN1 ",
            "USBCAN2 ",
            "PCI9820 ",
            "PCI5110 ",
            "PC104CAN ",
            "CANETUDP ",
            "PCI9840 ",
            "PC104CAN2",
            "PCI9820I ",
            "CANET-TCP",
            "PCI-5010-U",
            "USBCAN-E-U",
            "USBCAN-2E-U",
            "PCI-5020-U",
            "PCIE-9221",
            "CANWIFI-TCP",
            "CANWIFI-UDP",
            "PCIe-9110I"});
            this.DeviceT.Location = new System.Drawing.Point(154, 36);
            this.DeviceT.Name = "DeviceT";
            this.DeviceT.Size = new System.Drawing.Size(128, 26);
            this.DeviceT.TabIndex = 1;
            this.DeviceT.ValueMember = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FIU_Controler.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(736, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeviceT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DeIn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Ch);
            this.groupBox2.Location = new System.Drawing.Point(56, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 218);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // FIU_C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 390);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StartDe);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FIU_C";
            this.Text = "FIU_Controler";
            this.Load += new System.EventHandler(this.FIU_C_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DeIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Ch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Baud;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Timer1label;
        private System.Windows.Forms.TextBox Timer0;
        private System.Windows.Forms.TextBox Timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Default;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button StartDe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DeviceT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

