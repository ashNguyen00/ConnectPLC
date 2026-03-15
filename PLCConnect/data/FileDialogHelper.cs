using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCConnect
{
    public static class FileDialogHelper
    {
        // Mở 1 file
        public static string ShowOpenFileDialog(string title = "Open file",
                                                string initialDirectory = "",
                                                string filter = "All files (*.*)|*.*")
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = title;
                dlg.InitialDirectory = initialDirectory;
                dlg.Filter = filter;
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
                return null;
            }
        }

        // Mở nhiều file
        public static string[] ShowOpenFilesDialog(string title = "Select files",
                                                   string initialDirectory = "",
                                                   string filter = "All files (*.*)|*.*")
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = title;
                dlg.InitialDirectory = initialDirectory;
                dlg.Filter = filter;
                dlg.Multiselect = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileNames;
                return Array.Empty<string>();
            }
        }

        // Save file
        public static string ShowSaveFileDialog(string title = "Save file",
                                                string initialDirectory = "",
                                                string filter = "All files (*.*)|*.*",
                                                string defaultFileName = "")
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = title;
                dlg.InitialDirectory = initialDirectory;
                dlg.Filter = filter;
                dlg.FileName = defaultFileName;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.FileName;
                return null;
            }
        }

        // Chọn thư mục (FolderBrowserDialog)
        public static string ShowSelectFolderDialog(string description = "Select folder",
                                                    string initialDirectory = "")
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = description;
                dlg.SelectedPath = initialDirectory;
                dlg.ShowNewFolderButton = true;
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                    return dlg.SelectedPath;
                return null;
            }
        }
    }
}
