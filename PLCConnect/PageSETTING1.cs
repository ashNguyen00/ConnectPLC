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
        SerialObj mSerialInfor;
        public string pInputPath = "";
        public string pOutputDir = "";
        public bool exportExcelUse = false;
        public int exportExcelRows = 10;

        public PageSETTING1()
        {
            InitializeComponent();
        }

        public void reloadPropertyGridSerial()
        {

            pInputPath = ManagerInfor.Instance.excelOrgFilePath;
            pOutputDir = ManagerInfor.Instance.excelTarFolder;
            lblInputFile.Text = pInputPath;
            lblOutputFile.Text = pOutputDir;
            mSerialInfor = ManagerInfor.Instance.PropertyGridObj;
            propertyGrid1.SelectedObject = mSerialInfor;
            this.Validate();
        }

        public PageSETTING1(ProcessMain procMain)
        {
            InitializeComponent();
            main = procMain;
            reloadPropertyGridSerial();
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            ManagerInfor.Instance.rowExportExcel = exportExcelRows;
            ManagerInfor.Instance.useExportExcel = exportExcelUse;
            ManagerInfor.Instance.excelOrgFilePath = pInputPath;
            ManagerInfor.Instance.excelTarFolder = pOutputDir;
            ManagerInfor.Instance.PropertyGridObj = mSerialInfor;
            ManagerInfor.Instance.Save();
        }

        private void lbLoad_Click(object sender, EventArgs e)
        {
            ManagerInfor.Instance.Load();
            reloadPropertyGridSerial();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void lblInputFile_Click(object sender, EventArgs e)
        {
            if (main == null) return;

            pInputPath = PickFile("Select a file", $"");
            if (pInputPath != null)
            {
                lblInputFile.Text = pInputPath;
            }

        }

        private void lblOutputFile_Click(object sender, EventArgs e)
        {

            pOutputDir = PickFolder("Select a Folder", $"");
            if (pOutputDir != null)
            {
                lblOutputFile.Text = pOutputDir;
            }
        }
        public static string PickFolder(string description = "Chọn thư mục", string initialPath = "")
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = description;
                dlg.ShowNewFolderButton = true;
                if (!string.IsNullOrEmpty(initialPath))
                    dlg.SelectedPath = initialPath;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string dir = dlg.SelectedPath;
                    return dir;
                }
                return null;
            }
        }

        public static string PickFile(string description = "Chọn thư mục", string initialPath = "")
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn file";
                //dlg.Filter = "Text Files (*.xlsx)|All Files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dlg.FileName;
                    return filePath;
                }
                return null;
            }
        }

        private void lblExcelRowsCount_Click(object sender, EventArgs e)
        {
            using (FormNumpad dlg = new FormNumpad(lblExcelRowsCount.Text, false))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string port = dlg.getNewValue();
                    lblExcelRowsCount.Text = port;
                }
            }
        }

        private void lblExcelExport_Click(object sender, EventArgs e)
        {
            exportExcelUse = !exportExcelUse;
            lblExcelExport.Text = (exportExcelUse) ? "USE" : "NOT USE";
        }
    }
}
