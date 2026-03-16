using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCConnect
{
    public partial class FormHome : Form
    {
        PageHOME mPageHome;
        PageSETTING1 mPageSETTING;
        ProcessMain main;
        public FormHome()
        {
            InitializeComponent();
            
            main = new ProcessMain();
            mPageHome = new PageHOME(main);
            mPageSETTING = new PageSETTING1(main);

            mPageSETTING.Dock = System.Windows.Forms.DockStyle.Fill;
            mPageSETTING.Location = new System.Drawing.Point(0, 0);
            mPageSETTING.Name = "pageSETTING1";
            mPageSETTING.Size = new System.Drawing.Size(798, 318);
            mPageSETTING.TabIndex = 1;

            mPageHome.Dock = System.Windows.Forms.DockStyle.Fill;
            mPageHome.Location = new System.Drawing.Point(0, 0);
            mPageHome.Name = "pageSETTING1";
            mPageHome.Size = new System.Drawing.Size(798, 318);
            mPageHome.TabIndex = 1;

            main.pRS485Clent.OnDataChanged += mPageHome.updatePLCData;
            main.pRS485Clent.OnConnectedStatusChanged += updatePLCData;
            pnDisplay.Controls.Add(mPageHome);
            pnDisplay.Controls.Add(mPageSETTING);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        public void updatePLCData(string data)
        {
            if (lblConnectStatus.InvokeRequired)
            {
                lblConnectStatus.Invoke(new Action(() =>
                {
                    lblConnectStatus.Text = data;
                }));
            }
            else
            {
                lblConnectStatus.Text = data;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            mPageSETTING.reloadPropertyGridSerial();
            mPageSETTING.Visible = false;
            mPageHome.Visible = true;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Validate();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            mPageSETTING.reloadPropertyGridSerial();
            mPageHome.Visible = false;
            mPageSETTING.Visible = true;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Validate();
        }

        private void lblConnectStatus_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (main == null) return;
            lblConnectStatus.Text = main.pConnectState;
        }
    }
}
