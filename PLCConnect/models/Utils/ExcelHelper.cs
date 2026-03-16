using OfficeOpenXml;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PLCConnect
{
    public class ExcelHelper
    {
        private ExcelPackage package;
        private ExcelWorksheet ws;

        public Thread pThreadUpdate;

        public int pRow = 2;
        public int pFileIndex = 1;
        public int pMaxRow = 100;

        public ConcurrentQueue<double[]> pDataStores = new ConcurrentQueue<double[]>();

        private string templatePath;
        private string outputFolder;

        object lockSave = new object();

        public ExcelHelper(string template, string folder)
        {
            templatePath = template;
            outputFolder = folder;

            CreateNewFile();

            pThreadUpdate = new Thread(UpdatePolling);
            pThreadUpdate.IsBackground = true;
            pThreadUpdate.Start();
        }

        private void CreateNewFile()
        {
            string file = Path.Combine(outputFolder, $"result_{pFileIndex}.xlsx");

            FileInfo template = new FileInfo(templatePath);
            FileInfo output = new FileInfo(file);

            package = new ExcelPackage(output, template);
            ws = package.Workbook.Worksheets["Sheet1"];

            pRow = 2;
        }

        public void AddRowPolling(double[] datas)
        {
            for (int i = 0; i < datas.Length; i++)
            {
                ws.Cells[pRow, i + 1].Value = datas[i];
            }

            pRow++;
        }

        public void Save()
        {
            lock (lockSave)
            {
                package.Save();
                package.Dispose();

                pFileIndex++;
                CreateNewFile();
            }
        }

        public void UpdatePolling()
        {
            while (true)
            {
                try
                {
                    if (pDataStores.TryDequeue(out double[] data))
                    {
                        AddRowPolling(data);
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }


                    if (pRow > pMaxRow)
                    {
                        Task.Run(() => Save());
                    }
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}