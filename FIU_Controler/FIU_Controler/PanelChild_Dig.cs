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
    public partial class PanelChild_Dig : Form
    {

        int Dig_PnIndex;
        public PanelChild_Dig(int Dig_index, UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, byte m_connect)
        {
            InitializeComponent();
            Dig_PnIndex = Dig_index;
            label1.Text = Dig_PnIndex.ToString(); 
        }
    }
}
