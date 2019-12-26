using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIU_Controler
{
    public partial class FIU_C : Form
    {
        public FIU_C()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//设置form1的开始位置为屏幕的中央
        }

        
        
         
       
        private void FIU_C_Load(object sender, EventArgs e)
        {
            DeviceT.Text = "USBCAN2";
            DeIn.Text = "0";
            Ch.Text = "0";
            Baud.Text = "500";

            Timer0.Text = "00";
            Timer1.Text = "1C";
            Timer0.Enabled = false;
            Timer1.Enabled = false;
            this.ControlBox = false;
        }

        private void Default_Click(object sender, EventArgs e)
        {
            DeviceT.Text = "USBCAN2";
            DeIn.Text = "0";
            Ch.Text = "0";
            Baud.Text = "500";

            Timer0.Text = "00";
            Timer1.Text = "1C";
            Timer0.Enabled = false;
            Timer1.Enabled = false;
            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(0);

        }

        private void StartDe_Click(object sender, EventArgs e)
        {
            
            
            //----------------------
            //数据传递
            PassValue.dict["DeviceType"] = DeviceTypeGet(DeviceT.Text);//CAN卡类型
            PassValue.dict["DeviceInd"] = Convert.ToUInt32(DeIn.Text);//设备索引
            PassValue.dict["CANInd"] = Convert.ToUInt32(Ch.Text);
            PassValue.dict["Tm0"] = Convert.ToByte(Timer0.Text,16);
            PassValue.dict["Tm1"] = Convert.ToByte(Timer1.Text,16);
            //Operator_F f2 = new Operator_F(PassValue.dict);
            //f2.Show();
            new Operator_F(PassValue.dict).Show();
            //----------------------

            this.Close();
        }

        private void Baud_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BaudValue;
            BaudValue = Baud.SelectedItem.ToString();
            if (BaudValue == "1000")//1
            {
                Timer0.Text = "00";
                Timer1.Text = "14";
            }
            else if (BaudValue == "800")//2
            {
                Timer0.Text = "00";
                Timer1.Text = "16";
            }
            else if (BaudValue == "500")//3
            {
                Timer0.Text = "00";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "250")//4
            {
                Timer0.Text = "01";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "125")//5
            {
                Timer0.Text = "03";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "100")//6
            {
                Timer0.Text = "04";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "50")//7
            {
                Timer0.Text = "09";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "20")//8
            {
                Timer0.Text = "18";
                Timer1.Text = "1C";
            }
            else if (BaudValue == "10")//9
            {
                Timer0.Text = "31";
                Timer1.Text = "1C";
            }
            else//baud = 5kbps//10
            {
                Timer0.Text = "BF";
                Timer1.Text = "FF";
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Baud.Enabled = false;//baud disable
                Timer0.Enabled = true; //timer0 、timer1 enable
                Timer1.Enabled = true;
            }
            else
            {
                Baud.Enabled = true;//baud disable
                Timer0.Enabled = false; //timer0 、timer1 enable
                Timer1.Enabled = false;
            }
        }
       
        public UInt32 DeviceTypeGet(string str_device )
        {
            UInt32 dvtype = 0;
            switch (str_device)
            {
                case "PCI5121":
                    dvtype = 1;
                    break;
                case "PCI9810":
                    dvtype = 2;
                    break;
                case "USBCAN1":
                    dvtype = 3;
                    break;
                case "USBCAN2":
                    dvtype = 4;
                    break;
                case "PCI9820":
                    dvtype = 5;
                    break;
                case "PCI5110":
                    dvtype = 7;
                    break;
                case "PC104CAN":
                    dvtype = 8;
                    break;
                case "CANET-UDP":
                    dvtype = 9;
                    break;
                case "PCI9840N":
                    dvtype = 10;
                    break;
                case "PC104CAN2":
                    dvtype = 11;
                    break;
                case "PCI9820I":
                    dvtype = 12;
                    break;
                case "CANET-TCP":
                    dvtype = 13;
                    break;
                case "PCI-5010-U":
                    dvtype = 14;
                    break;
                case "USBCAN-E-U":
                    dvtype = 15;
                    break;
                case "USBCAN-2E-U":
                    dvtype = 16;
                    break;
                case "PCI-5020-U":
                    dvtype = 17;
                    break;
                case "PCIE-9221":
                    dvtype = 18;
                    break;
                case "CANWIFI-TCP":
                    dvtype = 19;
                    break;
                case "CANWIFI-UDP":
                    dvtype = 20;
                    break;
            }
            return dvtype;
        }

      
    }
}
