using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCConnect
{
    public partial class PageSETTING1 : UserControl
    {
        ProcessMain main;
        public PageSETTING1()
        {
            InitializeComponent();
        }
        public PageSETTING1(ProcessMain procMain)
        {
            InitializeComponent();
            main = procMain;
            propertyGrid1.SelectedObject = SerialInfo.Instance;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SerialInfo.Instance.Save();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            SerialInfo.Instance.Save();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }
    }
}
