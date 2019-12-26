using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ECAN;


namespace FIU_Controler
{
    public partial class PanelChild_FIU : Form
    {
        //------------------------定义字段------------------------------------------
        int FIU_PnIndex = 1;
        CheckBox[,] FaultInfo  = new CheckBox[12,8];//实例化故障信息数组
        TextBox[] FaultBox = new TextBox[12];
        UInt32 DeviceType;
        UInt32 DeviceInd;
        UInt32 CANInd;
        byte m_connect;
        CAN_OBJ FIUmMsgT;//can发送结构体
        int LoadFlag = 0;//负载标志 0:无负载 1:有负载
        string LoadPictPath = "";//负载切换图片
        public uint FIUID;//发送ID，无负载：0x7DC 有负载：0x7DD
        public byte FIUBoardNUM = 1;    //板号:1~10，可拓展
        public byte FIUFunPassword = 51;//功能选则
        byte[] FIUChanle = new byte[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//设置通道故障类型
        int SendSuccFlag = 0;
        //-------------------------定义功能方法--------------------------------------
        public void FaultArrayAssignment()
        {
            //初始化故障信息数组
            //-----------1--------------
            FaultInfo[0,0] = CH1_1;
            FaultInfo[0,1] = CH1_2;
            FaultInfo[0,2] = CH1_3;
            FaultInfo[0,3] = CH1_4;
            FaultInfo[0,4] = CH1_5;
            //-----------2--------------
            FaultInfo[1,0] = CH2_1;
            FaultInfo[1,1] = CH2_2;
            FaultInfo[1,2] = CH2_3;
            FaultInfo[1,3] = CH2_4;
            FaultInfo[1,4] = CH2_5;
            //-----------3--------------
            FaultInfo[2,0] = CH3_1;
            FaultInfo[2,1] = CH3_2;
            FaultInfo[2,2] = CH3_3;
            FaultInfo[2,3] = CH3_4;
            FaultInfo[2,4] = CH3_5;
            //-----------4--------------
            FaultInfo[3,0] = CH4_1;
            FaultInfo[3,1] = CH4_2;
            FaultInfo[3,2] = CH4_3;
            FaultInfo[3,3] = CH4_4;
            FaultInfo[3,4] = CH4_5;
            //-----------5--------------
            FaultInfo[4,0] = CH5_1;
            FaultInfo[4,1] = CH5_2;
            FaultInfo[4,2] = CH5_3;
            FaultInfo[4,3] = CH5_4;
            FaultInfo[4,4] = CH5_5;
            //-----------6--------------
            FaultInfo[5,0] = CH6_1;
            FaultInfo[5,1] = CH6_2;
            FaultInfo[5,2] = CH6_3;
            FaultInfo[5,3] = CH6_4;
            FaultInfo[5,4] = CH6_5;
            //----------7---------------
            FaultInfo[6,0] = CH7_1;
            FaultInfo[6,1] = CH7_2;
            FaultInfo[6,2] = CH7_3;
            FaultInfo[6,3] = CH7_4;
            FaultInfo[6,4] = CH7_5;
            //----------8---------------
            FaultInfo[7,0] = CH8_1;
            FaultInfo[7,1] = CH8_2;
            FaultInfo[7,2] = CH8_3;
            FaultInfo[7,3] = CH8_4;
            FaultInfo[7,4] = CH8_5;
            //----------9---------------
            FaultInfo[8,0] = CH9_1;
            FaultInfo[8,1] = CH9_2;
            FaultInfo[8,2] = CH9_3;
            FaultInfo[8,3] = CH9_4;
            FaultInfo[8,4] = CH9_5;
            //----------10---------------
            FaultInfo[9,0] = CH10_1;
            FaultInfo[9,1] = CH10_2;
            FaultInfo[9,2] = CH10_3;
            FaultInfo[9,3] = CH10_4;
            FaultInfo[9,4] = CH10_5;
            //----------11---------------
            FaultInfo[10,0] = CH11_1;
            FaultInfo[10,1] = CH11_2;
            FaultInfo[10,2] = CH11_3;
            FaultInfo[10,3] = CH11_4;
            FaultInfo[10,4] = CH11_5;
            //----------12---------------
            FaultInfo[11,0] = CH12_1;
            FaultInfo[11,1] = CH12_2;
            FaultInfo[11,2] = CH12_3;
            FaultInfo[11,3] = CH12_4;
            FaultInfo[11,4] = CH12_5;

            //-------------------------
        }

        public void FaultInfoBox()
        {
            FaultBox[0] = InfoBox1;
            FaultBox[1] = InfoBox2;
            FaultBox[2] = InfoBox3;
            FaultBox[3] = InfoBox4;
            FaultBox[4] = InfoBox5;
            FaultBox[5] = InfoBox6;
            FaultBox[6] = InfoBox7;
            FaultBox[7] = InfoBox8;
            FaultBox[8] = InfoBox9;
            FaultBox[9] = InfoBox10;
            FaultBox[10] = InfoBox11;
            FaultBox[11] = InfoBox12;
        }
        void SltAllBox(bool BtVal, int Colum)
        {
            int[] tmp = new int[4];
            switch (Colum)
            {
                case 0:
                    {
                        SltAllChild(BtVal, 0);
                        if (BtVal)
                        {
                            //CLCSlt.Value = true;
                            COMSlt.Value = false;
                            BATSlt.Value = false;
                            GNDSlt.Value = false;
                            OpenSlt.Value = false;
                            tmp = new int[4] { 1, 2, 3, 4 };
                            foreach (int i in tmp)
                            {
                                SltAllChild(false, i);
                            }
                        }                         
                    };break;
                case 1:
                    {
                        SltAllChild(BtVal, 1);
                        if (BtVal)
                        {
                            CLCSlt.Value = false;
                            // OpenSlt.Value = true;
                            BATSlt.Value = false;
                            GNDSlt.Value = false;
                            OpenSlt.Value = false;
                            tmp = new int[4] { 0, 2, 3, 4 };
                            foreach (int i in tmp)
                            {
                                SltAllChild(false, i);
                            }
                        }       
                    }; break;
                case 2:
                    {
                        SltAllChild(BtVal, 2);
                        if (BtVal)
                        {
                            CLCSlt.Value = false;
                            COMSlt.Value = false;
                            // BATSlt.Value = true;
                            GNDSlt.Value = false;
                            OpenSlt.Value = false;
                            tmp = new int[4] { 0, 1, 3, 4 };
                            foreach (int i in tmp)
                            {
                                SltAllChild(false, i);
                            }
                        }                          
                    }; break;
                case 3:
                    {
                        SltAllChild(BtVal, 3);
                        if (BtVal)
                        {
                            CLCSlt.Value = false;
                            COMSlt.Value = false;
                            BATSlt.Value = false;
                            // GNDSlt.Value = true;
                            OpenSlt.Value = false;
                            tmp = new int[4] { 0, 1, 2, 4 };
                            foreach (int i in tmp)
                            {
                                SltAllChild(false, i);
                            }
                        }                                             
                    }; break;
                case 4:
                    {
                        SltAllChild(BtVal, 4);
                        if (BtVal)
                        {
                            CLCSlt.Value = false;
                            COMSlt.Value = false;
                            BATSlt.Value = false;
                            GNDSlt.Value = false;
                            OpenSlt.Value = true;
                            tmp = new int[4] { 0, 1, 2, 3 };
                            foreach (int i in tmp)
                            {
                                SltAllChild(false, i);
                            }
                        }                                         
                    }; break;
                default: break;
            }                         
        }

        void SltAllChild(bool BtVal, int Colum)
        {
            if (BtVal)
            {
                for (int i = 0; i <= 11; i++)
                {
                    FaultInfo[i, Colum].Checked = true;
                    FaultInfo[i, Colum].Enabled = true;
                }
            }
            else
            {
                for (int i = 0; i <= 11; i++)
                {
                    FaultInfo[i, Colum].Checked = false;
                }
            }
        }


        void Faultprotection()//防护程序
        {
            if (LoadFlag == 1)
            {
                for (int i = 0; i <= 11; i++)
                {
                    int fullflg = 0;
                    int col = 0;
                    for (int j = 0; j <= 4; j++)
                    {
                        if (FaultInfo[i, j].Checked == true)
                        {
                            fullflg = 1;//记录每一行是否有填充；
                            col = j; //记录该行被勾选的框的索引                                   
                        }
                    }
                    if (fullflg == 1)//如果该行有框被选中，禁用其他框
                    {
                        for (int j = 0; j <= 4; j++)
                        {
                            if (col == 0)
                            {
                                int[] tmp = new int[] { 1, 2, 3, 4 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 1)
                            {
                                int[] tmp = new int[] { 0, 2, 3, 4 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 2)
                            {
                                int[] tmp = new int[] { 1, 0, 3, 4 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 3)
                            {
                                int[] tmp = new int[] { 1, 2, 0, 4 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 4)
                            {
                                int[] tmp = new int[] { 1, 2, 3, 0 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                        }

                    }
                    else//如果该行没有框被选中，使能该行所有框选
                    {
                        int[] tmp = new int[] { 0, 1, 2, 3, 4 };
                        foreach (int k in tmp)
                        {
                            // FaultInfo[i, k].Checked = false;
                            FaultInfo[i, k].Enabled = true;
                        }
                    }
                }
            }

            else //无负载情况下，开路复选框这一列不使能
            {
                for (int i = 0; i <= 11; i++)
                {
                    int fullflg = 0;
                    int col = 0;
                    for (int j = 0; j <= 3; j++)
                    {
                        if (FaultInfo[i, j].Checked == true)
                        {
                            fullflg = 1;//记录每一行是否有填充；
                            col = j; //记录该行被勾选的框的索引                                   
                        }
                    }
                    if (fullflg == 1)//如果该行有框被选中，禁用其他框
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            if (col == 0)
                            {
                                int[] tmp = new int[] { 1, 2, 3 };
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 1)
                            {
                                int[] tmp = new int[] { 0, 2, 3};
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 2)
                            {
                                int[] tmp = new int[] { 1, 0, 3};
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }
                            else if (col == 3)
                            {
                                int[] tmp = new int[] { 1, 2, 0};
                                foreach (int k in tmp)
                                {
                                    FaultInfo[i, k].Checked = false;
                                    FaultInfo[i, k].Enabled = false;
                                }
                            }                          
                        }
                    }
                    else//如果该行没有框被选中，使能该行所有框选
                    {
                        int[] tmp = new int[] { 0, 1, 2, 3 };
                        foreach (int k in tmp)
                        {
                            // FaultInfo[i, k].Checked = false;
                            FaultInfo[i, k].Enabled = true;
                        }
                    }
                }
            }
        }
        void ClcSltFault()
        {
            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    FaultInfo[i, j].Checked = false;
                }
            }
        }

        public void FIU_InfoCllct( )//发送信息收集
        {
            
            if (LoadFlag == 0)//有无负载判断 0：无负载 1：有负载 -------------------------1
            {
                FIUID = 0x7DC;
            }
            else
            {
                FIUID = 0x7DD;
            }
            FIUBoardNUM = Convert.ToByte(FIU_PnIndex);//故障板卡号----------------------2
            byte FunTmp = Convert.ToByte(ConfigModeSlt.SelectedIndex + 1);//Bit8~bit15 功能选则-------------------3
            switch (FunTmp)
            {
                case 1: FIUFunPassword = 0x55; break;//1:回读板卡的FIU配置，对应状态的ID为7DB
                case 2: FIUFunPassword = 0x5a; break;//2:停止发送板卡的FIU配置，对应状态的ID为7DB
                case 3: FIUFunPassword = 0x66; break; //3:回读所有板卡的FIU配置，对应状态的ID为7DB
                case 4: FIUFunPassword = 0x6a; break;//4:停止发送所有板卡的FIU配置，对应状态的ID为7DB
                case 5: FIUFunPassword = 0x33; break;//5:FIU板卡进入配置模式
                case 6: FIUFunPassword = 0xee; break;//6:重置对应板卡的FIU配置
                case 7: FIUFunPassword = 0xff; break;//7:重置所有板卡的FIU配置
                case 8: FIUFunPassword = 0xaa; break;//8:FIU板卡烧录应用层
            }
            FIU_ChanleGet(out FIUChanle);//通道故障类型获取函数-------------------4
        }

        void FIU_ChanleGet(out byte[] FIUChanleTmp)//通道故障类型获取
        {
            FIUChanleTmp =  new byte[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//设置通道故障类型 
            
            for (int i = 0; i <= 11; i++)//遍历行
            {
                int coltmp = 0;//记录选中的列
                int SltFlg = 0;//故障选中标志
                for (int j = 0; j <= 4; j++)//遍历列
                {
                    if (FaultInfo[i, j].Checked == true)
                    {
                        SltFlg = 1;
                        coltmp = j;
                        switch (coltmp)
                        {
                            case 0: FIUChanleTmp[i] = (LoadFlag == 0) ? Convert.ToByte(6) : Convert.ToByte(6); break;//清除故障     不带载：带载 6 ：6
                            case 1: FIUChanleTmp[i] = (LoadFlag == 0) ? Convert.ToByte(4) : Convert.ToByte(4); break;//共轨故障     不带载：带载 4 ：4
                            case 2: FIUChanleTmp[i] = (LoadFlag == 0) ? Convert.ToByte(1) : Convert.ToByte(1); break;//接电源故障   不带载：带载 1 ：1
                            case 3: FIUChanleTmp[i] = (LoadFlag == 0) ? Convert.ToByte(2) : Convert.ToByte(2); break;//接地故障     不带载：带载 2 ：2
                            case 4: FIUChanleTmp[i] = (LoadFlag == 0) ? Convert.ToByte(0) : Convert.ToByte(8); break;//开路故障     不带载：带载 0 ：8

                        }
                    }
                }
                if (SltFlg == 0)
                {
                    FIUChanleTmp[i] = 0;
                }
            }
        }

        void OpenCircle(bool BoolFlg)//显示或者关闭开路故障选择按钮
        {
            for (int i = 0; i <= 11; i++)
            {
                FaultInfo[i, 4].Enabled = BoolFlg;
            }

            OpenSlt.Enabled = BoolFlg;

        }
        void CANSendEncasement()//CAN发送装箱
        {
            FIUmMsgT.ID = FIUID;//ID
            FIUmMsgT.SendType = 0;//?
            FIUmMsgT.data = new byte[8];
            FIUmMsgT.Reserved = new byte[3];
            FIUmMsgT.DataLen = 8;
            FIUmMsgT.ExternFlag = 0;//标准帧
            FIUmMsgT.RemoteFlag = 0;//非远程帧
            int mlen = FIUmMsgT.DataLen - 1;
            for (int i = 0; i <= mlen; i++)
            {
                if (i == 0)
                {
                    FIUmMsgT.data[i] = FIUBoardNUM;
                }
                else if (i == 1)
                {
                    FIUmMsgT.data[i] = FIUFunPassword;
                }
                else if (i == 2)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[1] << 4) + (FIUChanle[0] & 0x0F));
                }
                else if (i == 3)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[3] << 4) + (FIUChanle[2] & 0x0F));
                }
                else if (i == 4)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[5] << 4) + (FIUChanle[4] & 0x0F));
                }
                else if (i == 5)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[7] << 4) + (FIUChanle[6] & 0x0F));
                }
                else if (i == 6)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[9] << 4) + (FIUChanle[8] & 0x0F));
                }
                else if (i == 7)
                {
                    FIUmMsgT.data[i] = Convert.ToByte((FIUChanle[11] << 4) + (FIUChanle[10] & 0x0F));
                }
            }
        }
        void CANSendFunc()
        {
            if (m_connect != 1)
            {
                MessageBox.Show("No CAN connection!");
                return;
            }
            uint mLen = 1;
            int SendFailFlg = 0;
            CAN_OBJ[] mMsg1 = new CAN_OBJ[1];
            mMsg1[0] = FIUmMsgT;
            SendSuccFlag = 0;
            for (int i = 0; i <= 9; i++)
            {
                if (CANAPIData.ECANDLL.Transmit(DeviceType, DeviceInd, CANInd, mMsg1, mLen, 1) == ECANStatus.STATUS_OK)
                {
                    SendSuccFlag = 1; //发送成功标志
                }
                else
                {
                    SendFailFlg++;
                }
                if (SendFailFlg == 9)
                {
                    MessageBox.Show("CAN transmit failure !");
                }

            }

        } 
        void FaultMessageShow()//故障信息发送成功显示
        {
            if (SendSuccFlag == 1)//发送成功
            {
                for (int i = 0; i <= 11; i++)
                {
                    switch (FIUChanle[i])
                    {
                        case 0: FaultBox[i].Text = ""; break;
                        case 1: FaultBox[i].Text = "Short to Vcc(Vbat) mode sent successfully！"; break;
                        case 2: FaultBox[i].Text = "Short to Gnd mode sent successfully！"; break;
                        case 4: FaultBox[i].Text = "Common rail mode sent successfully！"; break;
                        case 6: FaultBox[i].Text = "Clear mode sent successfully！"; break;
                        case 8: FaultBox[i].Text = "Open mode sent successfully！"; break;
                        default:break;
                    }
                }
            }
        }
        //-------------------------方法结束-----------------------------------



        public PanelChild_FIU(int FIU_index, UInt32 DeviceTypeTmp, UInt32 DeviceIndTmp, UInt32 CANIndTmp, byte m_connectTmp)
                            //构造函数(故障板卡的索引号，CAN卡的类型，设备索引、CAN索引，连接成功标志)
        {
            InitializeComponent();

            FIU_PnIndex = FIU_index;
            label1.Text = FIU_PnIndex.ToString();

            FaultArrayAssignment();//初始化故障信息数组  
            FaultInfoBox();//初始化故障信息存储BOX
            OpenCircle(false);//不显示开路故障选择
            DeviceType = DeviceTypeTmp;
            DeviceInd = DeviceIndTmp;
            CANInd = CANIndTmp;
            m_connect = m_connectTmp;
        }

       
        private void LoadOn_Click(object sender, EventArgs e)
        {
            string StartAppPth = Application.StartupPath;

            if (LoadFlag == 0)
            {
                LoadPictPath = "\\Lyes4.png";
                LoadPictPath = StartAppPth + LoadPictPath;
                LoadFlag = 1;//
                OpenCircle(true);//显示开路故障选择

            }
            else
            {
                LoadPictPath = "\\Lno3.png";
                LoadPictPath = StartAppPth + LoadPictPath;
                LoadFlag = 0;
                OpenCircle(false);//不显示开路故障选择
            }
            var Pct = new Bitmap(LoadPictPath);
            LoadOn.BackgroundImage = Pct;
        }

        private void CLCSlt_ValueChanged(object sender, EventArgs e)//Clear控件全选和全不选
        {
            SltAllBox(CLCSlt.Value, 0);
        }
        private void COMSlt_ValueChanged_1(object sender, EventArgs e)
        {
            SltAllBox(COMSlt.Value, 1);
        }


        private void BATSlt_ValueChanged(object sender, EventArgs e)
        {
            SltAllBox(BATSlt.Value, 2);  
        }

        private void GNDSlt_ValueChanged(object sender, EventArgs e)
        {
            SltAllBox(GNDSlt.Value, 3); 
        }
     

        private void OpenSlt_ValueChanged(object sender, EventArgs e)
        {
            SltAllBox(OpenSlt.Value, 4);
        }


        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            Faultprotection();
        }

        private void ClcSltFlt_Click(object sender, EventArgs e)
        {
            ClcSltFault();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                FaultBox[i].Text = "";
            }
        }
      

        private void Action_Click(object sender, EventArgs e)
        {
            if (FIUMode.Value == false)//通过界面设置进行故障注入
            {
                //1、收集待发送的信息
                //2、执行发送
                //3、将发送信息显示在信息框中
                FIU_InfoCllct();
                CANSendEncasement();
                CANSendFunc();
                FaultMessageShow();
            }
            else//通过EXCEL进行自动化的故障注入
            {


            }
           
        }

        private void ConfigModeSlt_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (ConfigModeSlt.SelectedIndex)
            {
                case 0: ModeShow.Text = "CurrentMode:Enable Readback FIUState"; break;
                case 1: ModeShow.Text = "CurrentMode:Disable Readback FIUState"; break;
                case 2: ModeShow.Text = "CurrentMode:Enable ALLReadback FIUState"; break;
                case 3: ModeShow.Text = "CurrentMode:Disable ALLReadback FIUState"; break;
                case 4: ModeShow.Text = "CurrentMode:Config Mode"; break;
                case 5: ModeShow.Text = "CurrentMode:Reset according to BoardNum"; break;
                case 6: ModeShow.Text = "CurrentMode:Reset ALL Board Num"; break;
                case 7: ModeShow.Text = "CurrentMode:Boot loader Download"; break;
                default: break;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel文件(*.xlsx)|*.xlsx|所有文件|*.*";
            //DialogResult dlgResult = new DialogResult();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ExcelPath.Text = dlg.FileName;//向文本框中填写打开的EXCEL名称+路径
                ExcelLib.IExcel tmp = ExcelLib.PreExcel.GetExcel(ExcelPath.Text);
                if (tmp == null & !tmp.Open())
                {
                    MessageBox.Show("File Not Found!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ShetName.DataSource = tmp.GetWorkSheets();
                tmp.Close();
                ElxEditor.Enabled = true;
                TitleRow.Text = "0";

            }
        }

        private void ElxEditor_Click(object sender, EventArgs e)
        {
            PassValue.dict["ExcelPath"] = ExcelPath.Text;
            ExcelEditor elx = new ExcelEditor(PassValue.dict);
            elx.Show();
        }
    }
}
