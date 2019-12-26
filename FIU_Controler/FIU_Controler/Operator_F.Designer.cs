namespace FIU_Controler
{
    partial class Operator_F
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operator_F));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClcRec = new System.Windows.Forms.Button();
            this.CANCfg = new System.Windows.Forms.Button();
            this.SendMsg = new System.Windows.Forms.Button();
            this.Canled = new SeeSharpTools.JY.GUI.LED();
            this.Reset = new System.Windows.Forms.Button();
            this.Receive = new System.Windows.Forms.Button();
            this.OpenDevice = new System.Windows.Forms.Button();
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.Receivelist = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelList = new System.Windows.Forms.TreeView();
            this.ConInfo = new System.Windows.Forms.TextBox();
            this.OpenConfig = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clrlst = new System.Windows.Forms.Button();
            this.ConFigReadDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClcRec);
            this.groupBox1.Controls.Add(this.CANCfg);
            this.groupBox1.Controls.Add(this.SendMsg);
            this.groupBox1.Controls.Add(this.Canled);
            this.groupBox1.Controls.Add(this.Reset);
            this.groupBox1.Controls.Add(this.Receive);
            this.groupBox1.Controls.Add(this.OpenDevice);
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set";
            // 
            // ClcRec
            // 
            this.ClcRec.Location = new System.Drawing.Point(176, 73);
            this.ClcRec.Name = "ClcRec";
            this.ClcRec.Size = new System.Drawing.Size(131, 36);
            this.ClcRec.TabIndex = 13;
            this.ClcRec.Text = "ClcRec";
            this.ClcRec.UseVisualStyleBackColor = true;
            this.ClcRec.Click += new System.EventHandler(this.ClcRec_Click);
            // 
            // CANCfg
            // 
            this.CANCfg.Location = new System.Drawing.Point(381, 20);
            this.CANCfg.Name = "CANCfg";
            this.CANCfg.Size = new System.Drawing.Size(86, 36);
            this.CANCfg.TabIndex = 4;
            this.CANCfg.Text = "CANCfg";
            this.CANCfg.UseVisualStyleBackColor = true;
            this.CANCfg.Click += new System.EventHandler(this.CANCfg_Click);
            // 
            // SendMsg
            // 
            this.SendMsg.Location = new System.Drawing.Point(339, 75);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(128, 35);
            this.SendMsg.TabIndex = 12;
            this.SendMsg.Text = "SendMsg";
            this.SendMsg.UseVisualStyleBackColor = true;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // Canled
            // 
            this.Canled.BlinkColor = System.Drawing.Color.Lime;
            this.Canled.BlinkInterval = 1000;
            this.Canled.BlinkOn = false;
            this.Canled.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Canled.Interacton = SeeSharpTools.JY.GUI.LED.InteractionStyle.Indicator;
            this.Canled.Location = new System.Drawing.Point(339, 20);
            this.Canled.Name = "Canled";
            this.Canled.OffColor = System.Drawing.Color.Gray;
            this.Canled.OnColor = System.Drawing.Color.Lime;
            this.Canled.Size = new System.Drawing.Size(36, 34);
            this.Canled.Style = SeeSharpTools.JY.GUI.LED.LedStyle.Circular;
            this.Canled.TabIndex = 3;
            this.Canled.Value = false;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(176, 25);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(131, 29);
            this.Reset.TabIndex = 1;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Receive
            // 
            this.Receive.Location = new System.Drawing.Point(38, 74);
            this.Receive.Name = "Receive";
            this.Receive.Size = new System.Drawing.Size(120, 36);
            this.Receive.TabIndex = 3;
            this.Receive.Text = "Receive";
            this.Receive.UseVisualStyleBackColor = true;
            this.Receive.Click += new System.EventHandler(this.Receive_Click);
            // 
            // OpenDevice
            // 
            this.OpenDevice.Location = new System.Drawing.Point(38, 22);
            this.OpenDevice.Name = "OpenDevice";
            this.OpenDevice.Size = new System.Drawing.Size(120, 34);
            this.OpenDevice.TabIndex = 0;
            this.OpenDevice.Text = "OpenDevice";
            this.OpenDevice.UseVisualStyleBackColor = true;
            this.OpenDevice.Click += new System.EventHandler(this.OpenDevice_Click);
            // 
            // lbxInfo
            // 
            this.lbxInfo.FormattingEnabled = true;
            this.lbxInfo.ItemHeight = 18;
            this.lbxInfo.Location = new System.Drawing.Point(1017, 40);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.ScrollAlwaysVisible = true;
            this.lbxInfo.Size = new System.Drawing.Size(355, 670);
            this.lbxInfo.TabIndex = 2;
            // 
            // Receivelist
            // 
            this.Receivelist.FormattingEnabled = true;
            this.Receivelist.ItemHeight = 18;
            this.Receivelist.Location = new System.Drawing.Point(0, 125);
            this.Receivelist.Name = "Receivelist";
            this.Receivelist.Size = new System.Drawing.Size(965, 508);
            this.Receivelist.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 706);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.PanelList);
            this.tabPage1.Controls.Add(this.ConInfo);
            this.tabPage1.Controls.Add(this.OpenConfig);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(989, 674);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control";
            // 
            // PanelList
            // 
            this.PanelList.FullRowSelect = true;
            this.PanelList.Location = new System.Drawing.Point(60, 223);
            this.PanelList.Name = "PanelList";
            this.PanelList.Size = new System.Drawing.Size(385, 434);
            this.PanelList.TabIndex = 3;
            this.PanelList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.PanelList_NodeMouseDoubleClick);
            // 
            // ConInfo
            // 
            this.ConInfo.Location = new System.Drawing.Point(190, 169);
            this.ConInfo.Name = "ConInfo";
            this.ConInfo.Size = new System.Drawing.Size(318, 28);
            this.ConInfo.TabIndex = 2;
            // 
            // OpenConfig
            // 
            this.OpenConfig.Location = new System.Drawing.Point(47, 161);
            this.OpenConfig.Name = "OpenConfig";
            this.OpenConfig.Size = new System.Drawing.Size(113, 34);
            this.OpenConfig.TabIndex = 1;
            this.OpenConfig.Text = "OpenConfig";
            this.OpenConfig.UseVisualStyleBackColor = true;
            this.OpenConfig.Click += new System.EventHandler(this.OpenConfig_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(989, 674);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dispaly";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.Receivelist);
            this.groupBox3.Location = new System.Drawing.Point(-4, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(985, 625);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MessageShow";
            // 
            // clrlst
            // 
            this.clrlst.Location = new System.Drawing.Point(1015, 8);
            this.clrlst.Name = "clrlst";
            this.clrlst.Size = new System.Drawing.Size(83, 32);
            this.clrlst.TabIndex = 8;
            this.clrlst.Text = "Clear";
            this.clrlst.UseVisualStyleBackColor = true;
            this.clrlst.Click += new System.EventHandler(this.Clrlst_Click);
            // 
            // ConFigReadDlg
            // 
            this.ConFigReadDlg.FileName = "ConFigReadDlg";
            // 
            // Operator_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 735);
            this.Controls.Add(this.clrlst);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Operator_F";
            this.Text = "Operator_F";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Operator_F_FormClosing);
            this.Load += new System.EventHandler(this.Operator_F_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OpenDevice;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.ListBox lbxInfo;
        private SeeSharpTools.JY.GUI.LED Canled;
        private System.Windows.Forms.ListBox Receivelist;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clrlst;
        private System.Windows.Forms.Button CANCfg;
        private System.Windows.Forms.Button Receive;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.Button ClcRec;
        private System.Windows.Forms.OpenFileDialog ConFigReadDlg;
        private System.Windows.Forms.TextBox ConInfo;
        private System.Windows.Forms.Button OpenConfig;
        private System.Windows.Forms.TreeView PanelList;
    }
}