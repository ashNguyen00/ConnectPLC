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
    public partial class PageHOME : UserControl
    {
        ProcessMain main;
        public PageHOME()
        {
            InitializeComponent();
        }
        public PageHOME(ProcessMain procMain)
        {
            InitializeComponent();
            main = procMain;
        }
        public void updatePLCData(ushort[] data)
        {
            string mData = "";
            for(int i = 0; i <data.Length;i++) {
                mData += i.ToString("00") +"-" +data[i].ToString("00") + "   ";
            }
            if (richTextBox1.InvokeRequired) {
                richTextBox1.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(mData.ToString() + Environment.NewLine);
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }));
            }
            else {
                richTextBox1.AppendText(mData.ToString() + Environment.NewLine);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }
    }
}
