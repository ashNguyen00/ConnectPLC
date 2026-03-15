using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;


namespace PLCConnect
{
    public class ExcelWriter
    {
        private ExcelPackage package;
        private ExcelWorksheet ws;

        private int row = 2;
        private int fileIndex = 1;
        private int maxRow = 1000;

        private string templatePath;
        private string outputFolder;

        public ExcelWriter(string template, string folder)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            templatePath = template;
            outputFolder = folder;

            CreateNewFile();
        }

        private void CreateNewFile()
        {
            string file = Path.Combine(outputFolder, $"result_{fileIndex}.xlsx");

            FileInfo template = new FileInfo(templatePath);
            FileInfo output = new FileInfo(file);

            package = new ExcelPackage(output, template);
            ws = package.Workbook.Worksheets[0];

            row = 2;
        }

        public void AddRow(string name, int age, string address)
        {
            if (row > maxRow)
            {
                Save();
                fileIndex++;
                CreateNewFile();
            }

            ws.InsertRow(row, 1, row - 1);

            ws.Cells[row, 1].Value = name;
            ws.Cells[row, 2].Value = age;
            ws.Cells[row, 3].Value = address;

            row++;
        }

        public void Save()
        {
            package.Save();
            package.Dispose();
        }
    }
}
