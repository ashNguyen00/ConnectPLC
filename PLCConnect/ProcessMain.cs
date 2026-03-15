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
        public ProcessMain()
        {
            pRS485Clent = new ModbusRTUClient(
                1,
                SerialInfo.Instance.portName, 
                SerialInfo.Instance.baudrate,
                SerialInfo.Instance.readTimeout, 
                SerialInfo.Instance.writeTimeout
                );
            pRS485Clent.Connect();
        }
    }
}
