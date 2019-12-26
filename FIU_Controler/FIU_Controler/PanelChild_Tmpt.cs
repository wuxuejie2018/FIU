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
    public partial class PanelChild_Tmpt : Form
    {

        int Tmpt_PnINdex;
        public PanelChild_Tmpt(int Tmpt_index, UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, byte m_connect)
        {
            InitializeComponent();
            Tmpt_PnINdex = Tmpt_index;
            label1.Text = Tmpt_PnINdex.ToString();
        }
    }
}
