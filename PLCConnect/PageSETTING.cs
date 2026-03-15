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
    public partial class PageSETTING : UserControl
    {
        ProcessMain main;
        public PageSETTING()
        {
            InitializeComponent();
        }
        public PageSETTING(ProcessMain procMain)
        {
            main = procMain;
            InitializeComponent();
        }
    }
}
