using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCConnect
{
    public class ProcessMain
    {
        public ModbusRTUClient pRS485Clent;
        public ModbusRTUServer pRS485Server;
        public string pConnectState = "Disconnect";
        public ExcelHelper pExcelHelper;
        public ProcessMain()
        {
            pExcelHelper = new ExcelHelper(ManagerInfor.Instance.excelOrgFilePath, ManagerInfor.Instance.excelTarFolder);
            pRS485Clent = new ModbusRTUClient(
                1,
                ManagerInfor.Instance.PropertyGridObj.portName, 
                ManagerInfor.Instance.PropertyGridObj.baudrate,
                ManagerInfor.Instance.PropertyGridObj.readTimeout, 
                ManagerInfor.Instance.PropertyGridObj.writeTimeout
                );
            pRS485Clent.Connect();
        }
    }
}
