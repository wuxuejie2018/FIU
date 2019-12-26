using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECAN;
using static ECAN.CANAPIData;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;


namespace FIU_Controler
{
    
    public partial class Operator_F : Form
    {
        
        public Operator_F(Dictionary<string, object> dictmp)
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置form1的开始位置为屏幕的中央
            DeviceType = (UInt32) dictmp["DeviceType"];
            DeviceInd = (UInt32) dictmp["DeviceInd"];
            CANInd = (UInt32) dictmp["CANInd"];
            Tm0 =(byte) dictmp["Tm0"];
            Tm1 = (byte) dictmp["Tm1"];
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        //实例化canAPI类
        CANAPIData mCan = new CANAPIData();
        FunctionCall mCanF = new FunctionCall();

        //-----------------------------------属性定义-------------------------------------
        public Int64 LstStateBckInfo = 0;  //上一次故障注入反馈信息
        public Int64 NwStateBckInfo = 0;   //当前故障注入反馈信息
        public const byte Lowb = 0x0F;
        public const byte Hgtb = 0xF0;
        public static UInt32 DeviceType;
        public static  UInt32 DeviceInd;
        public static UInt32 CANInd;
        public static  byte Tm0;
        public static byte Tm1;
        byte m_connect;//CAN连接状态
        string[] PanelType = new string[20];//板卡类型
        string[] PanelNum = new string[20];//对应板卡类型的板卡号
        Thread canreclist;
        //-----------------------------------属性定义完成---------------------------------


        //-----------------------------------功能函数-------------------------------------
        private void IncludeTextMessage(string strMsg)
        {
            lbxInfo.Items.Add(strMsg);
            lbxInfo.SelectedIndex = lbxInfo.Items.Count - 1;
        }
        private void CallIncludeTextMessage(string strMsg)
        {
            string[] strtmp = strMsg.Split(',');
            foreach (string strtmp1 in strtmp)
            {
                IncludeTextMessage(strtmp1);
            }
            IncludeTextMessage("-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --");
        }

      
        public Thread CreatCANRThread()
        {
            ThreadStart canreclists = new ThreadStart//创建线程
           (() =>
           {
               while (true)
               {
                   CANReceive1();
                   CANReceive2();
               }
           }
            );
            Thread canreclistTmp = new Thread(canreclists);
            return canreclistTmp;
        }
   
      
        public void CANReceive1()

        {
            if (this.m_connect == 0)
            {
                //MessageBox.Show("Not open device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CallIncludeTextMessage("Not open device!");
                return;
            }
            CAN_OBJ mMsg = new CAN_OBJ();
            uint mLen = 1;
            if (ECANDLL.Receive(DeviceType, DeviceInd, CANInd, out mMsg, mLen, 1) == ECANStatus.STATUS_OK)
            {
                string tmpstr;



                string str = "Rec: ";
                if (mMsg.TimeFlag == 0)
                {
                    tmpstr = "Time:  ";
                }
                else
                {
                    tmpstr = "Time:" + string.Format("{0:X8}h", mMsg.TimeStamp);
                }
                str = str + tmpstr;
                tmpstr = "  ID:" + string.Format("{0:X8}h", mMsg.ID);
                str = str + tmpstr + " Format:";
                if (mMsg.RemoteFlag == 0)
                {
                    tmpstr = "Data ";
                }
                else
                {
                    tmpstr = "Romte ";
                }
                str = str + tmpstr + " Type:";
                if (mMsg.ExternFlag == 0)
                {
                    tmpstr = "Stand ";
                }
                else
                {
                    tmpstr = "Exten ";
                }
                str = str + tmpstr;
                if (mMsg.RemoteFlag == 0)
                {
                    str = str + " Data:";
                    if (mMsg.DataLen > 8)
                    {
                        mMsg.DataLen = 8;
                    }
                    int mlen = mMsg.DataLen - 1;
                    for (int j = 0; j <= mlen; j++)
                    {
                        tmpstr = string.Format("{0:X2} ", mMsg.data[j]);
                        str = str + tmpstr;
                    }
                }
                this.Receivelist.Items.Add(str);
                if (this.Receivelist.Items.Count > 500)
                {
                    this.Receivelist.Items.Clear();
                }


                Application.DoEvents();



            }
        }


        public void CANReceive2()
        {
            if (this.m_connect == 0)
            {
                CallIncludeTextMessage("Not open device!");
                return;
            }
            CAN_OBJ mMsg2 = new CAN_OBJ();
            uint mLen = 1;
            if (ECANDLL.Receive(DeviceType, DeviceInd, CANInd, out mMsg2, mLen, 1) == ECANStatus.STATUS_OK)
            {
               
            }
        }
        void CreatTreeNode(string[] PanelType,string[] PanelNum)
        {
            int cntmp = 0;
            foreach (string NodeNameTmp in PanelType)
            {

                TreeNode PannelTypeTmp = new TreeNode();
                PannelTypeTmp.Name = NodeNameTmp;
                PannelTypeTmp.Text = NodeNameTmp;
                string[] PanlNumName = PanelNum[cntmp].Split(',');
                TreeNode PanelChild = new TreeNode();
                foreach (string Panl in PanlNumName)
                {
                    PannelTypeTmp.Nodes.Add(Panl);

                }
                PanelList.Nodes.Add(PannelTypeTmp);
                cntmp = cntmp + 1;
            }
            PanelList.ExpandAll();
        }
     

        //-----------------------------------功能函数完成-------------------------------------
        private void Operator_F_Load(object sender, EventArgs e)
        {
          
        }

        private void OpenDevice_Click(object sender, EventArgs e)
        {
           
           // CanRFlag = 0;
            if (m_connect == 1)
            {
                m_connect = 0;
                ECANDLL.CloseDevice(DeviceType, DeviceInd);
                Canled.Value = false;
                OpenDevice.Text = "OpenDevice";
                Reset.Enabled = false;
                lbxInfo.Items.Clear();
                CallIncludeTextMessage("Device is closed!");
                //Write.Enabled = false;
                return;
            }

            INIT_CONFIG init_config = new INIT_CONFIG();//配置信息设置
            init_config.AccCode = 0;
            init_config.AccMask = 0xffffff;
            init_config.Filter = 0;
            init_config.Timing0 = Tm0;
            init_config.Timing1 = Tm1;
            init_config.Mode = 0;
            //--------------------------------------------------------------------------------


            if (ECANDLL.OpenDevice(DeviceType,DeviceInd, CANInd) != ECANStatus.STATUS_OK)//打开设备
            {
                CallIncludeTextMessage("Open device fault!");
                return;
            }
            else
            {
                CallIncludeTextMessage("Open device success!");
            }
            //Set can baud
            if (ECANDLL.InitCAN(DeviceType, DeviceInd, CANInd, ref init_config) != ECAN.ECANStatus.STATUS_OK)//初始化设备
            {
                CallIncludeTextMessage("Init can fault!");
                ECANDLL.CloseDevice(DeviceType, DeviceInd);
                Canled.Value = false;
                return;
            }
            else
            {
                CallIncludeTextMessage("Init can success!");
            }
            m_connect = 1;
            OpenDevice.Text = "CloseDevice";
            Reset.Enabled = true;
            CallIncludeTextMessage("Connect Success!");
            if (m_connect == 0)
            {
                CallIncludeTextMessage("Not open device!");
                return;
            }

            //Start Can
            if (ECANDLL.StartCAN(DeviceType, DeviceInd, CANInd) == ECANStatus.STATUS_OK)//启动设备
            {
                CallIncludeTextMessage("Start CAN Success!");
                Canled.Value = true;
            }
            else
            {
                CallIncludeTextMessage("Start Fault!");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
           // CanRFlag = 0;
            if (m_connect == 0)
            {
                CallIncludeTextMessage("Not open device!");
                return;
            }
            if (ECANDLL.ResetCAN(DeviceType, DeviceInd, CANInd) == ECANStatus.STATUS_OK)
            {
                CallIncludeTextMessage("Reset Success");
                Canled.Value = true;
                
            }
            else
            {
                CallIncludeTextMessage("Reset Fault");
            }

        }
       

       
        private void Receive_Click(object sender, EventArgs e)
        {


            //ThreadStart canrecs = new ThreadStart(canread);//can数据采集
            //Thread canrec = new Thread(canrecs);
            //canrec.Start();
            
            if (Receive.Text == "Stop")
            {
                Receive.Text = "Receive";
                canreclist.Abort();
            }
            else
            {
                Receive.Text = "Stop";
                canreclist = CreatCANRThread();//创建接收线程
                canreclist.Start();
            }      
        }

        private void SendMsg_Click(object sender, EventArgs e)
        {
            if (m_connect != 1)
            {
                CallIncludeTextMessage("Not open device!");
                return;
            }
            uint mLen = 1;
            CAN_OBJ[] mMsg1 = new CAN_OBJ[1];
           
           
            for (int i = 0; i <= 10;i ++)
            {
                if (ECANDLL.Transmit(DeviceType, DeviceInd, CANInd, mMsg1, mLen, 1) == ECANStatus.STATUS_OK)//消息发送判断
                {
                }
                else
                {
                }
            }  
        }

      

        private void Clrlst_Click(object sender, EventArgs e)
        {
            lbxInfo.Items.Clear();
        }

        private void Operator_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);//退出上位机系统
        }


        private void CANCfg_Click(object sender, EventArgs e)
        {
            if (m_connect == 0)
            {

                FIU_C FIU_C2 = new FIU_C();
                FIU_C2.Show(); 
                this.Hide();
            }
        }

        private void ClcRec_Click(object sender, EventArgs e)
        {
            Receivelist.Items.Clear();
        }

        private void OpenConfig_Click(object sender, EventArgs e)
        {
            string[] ConfigArray = {""};//定义配置信息列表字符数组         
            OpenFileDialog ConfigFile = new OpenFileDialog();
            ConfigFile.Filter = "文本文件(.ini)|*.ini";
            if (ConfigFile.ShowDialog() == DialogResult.OK)
            {
                string ConfigContent = "";
                string FName = ConfigFile.FileName;
                
                ConInfo.Text = FName;
                FName.Replace(@"\",@"\\");
                FileStream  frdconfig = File.OpenRead(FName);
                StreamReader frdconfigsw = new StreamReader(frdconfig,Encoding.Default);
                while (frdconfigsw.Peek() > -1)
                {
                    ConfigContent = ConfigContent + frdconfigsw.ReadLine() + "\n";
                }
                ConfigArray = ConfigContent.Split('\n');
                frdconfigsw.Close();
                frdconfig.Close();
            }
            if (ConfigArray != null)//收集配置信息
            {
                int Cnt = -1;
                bool ClcPnmFlg = false;
                foreach (string StrTmp in ConfigArray)
                {
                    Match PanelTypeTmp;
                    PanelTypeTmp = Regex.Match(StrTmp, @"@([\u4e00-\u9fa5]+.*)");//板卡类型提取（中文提取）
                    string PanelTypeTmpStr = PanelTypeTmp.Groups[1].Value;
                    Match PanelNumTmp;
                    // PanelNumTmp = Regex.Match(StrTmp, @"#\d*:(\w+\d*\n)");//板卡类型提取
                    PanelNumTmp = Regex.Match(StrTmp, @"#\d+:(.*)");//板卡类型提取
                    string PanelNumTmpStr = PanelNumTmp.Groups[1].Value;
                    if (PanelTypeTmpStr != "")
                    {
                        Cnt++;//Cnt从1开始计数
                        //转换为string
                        PanelType[Cnt] = PanelTypeTmpStr;
                        ClcPnmFlg = true;
                    }
                    if (PanelNumTmpStr != "")
                    {
                        if (ClcPnmFlg)
                        {
                            PanelNum[Cnt] = PanelNumTmpStr;
                            ClcPnmFlg = false;
                        }
                        else
                        {
                            PanelNum[Cnt] = PanelNum[Cnt] + "," + PanelNumTmpStr;
                        }
                        
                    }
                }
                PanelType = PanelType.Where(x => !string.IsNullOrEmpty(x)).ToArray();//去除数组中的null
                PanelNum = PanelNum.Where(x => !string.IsNullOrEmpty(x)).ToArray(); //去除数组中的null

                //当配置信息不为空时，自动读取信息到多级列表
                CreatTreeNode(PanelType, PanelNum);              
            }
        }
        PanelChild_FIU[] FIU = new PanelChild_FIU[20];//实例化20个
        PanelChild_Tmpt[] Tmpt = new PanelChild_Tmpt[20];//实例化20个
        PanelChild_Dig[] Dig = new PanelChild_Dig[20];//实例化20个

        private void PanelList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)//启动自卖那般
        {
            
            string  PanelWhich =e.Node.Text;
            int Index = e.Node.Index;//选择的板卡的索引号
            string ParentPanelWhich = e.Node.Parent.Text;
            if (m_connect == 1)//控制打开子面板的通信成功标志：0不成功，1成功
            {
                if (string.Equals(ParentPanelWhich, PanelType[0]))
                {
                    FIU[Index] = new PanelChild_FIU(Index + 1,  DeviceType,  DeviceInd,  CANInd,  m_connect);
                    FIU[Index].Name = ParentPanelWhich + "_" + PanelWhich;
                    FIU[Index].Text = ParentPanelWhich + "_" + PanelWhich;
                    FIU[Index].Show();
                }
                else if (string.Equals(ParentPanelWhich, PanelType[1]))
                {
                    Tmpt[Index] = new PanelChild_Tmpt(Index + 1, DeviceType, DeviceInd, CANInd, m_connect);
                    Tmpt[Index].Name = ParentPanelWhich + "_" + PanelWhich;
                    Tmpt[Index].Text = ParentPanelWhich + "_" + PanelWhich;
                    Tmpt[Index].Show();
                }
                else if (string.Equals(ParentPanelWhich, PanelType[2]))
                {
                    Dig[Index] = new PanelChild_Dig(Index + 1, DeviceType, DeviceInd, CANInd, m_connect);
                    Dig[Index].Name = ParentPanelWhich + "_" + PanelWhich;
                    Dig[Index].Text = ParentPanelWhich + "_" + PanelWhich;
                    Dig[Index].Show();
                }
                //后续添加板卡可在此处添加
                else
                {
                    MessageBox.Show("NoPanel in the List!");
                }
            }
            else
            {
                MessageBox.Show("No CAN connection! ");
            }


        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int a = 16;
        //}


        //多线程编程

    }
}
