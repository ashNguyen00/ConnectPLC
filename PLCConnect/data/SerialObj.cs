using Modbus.Device;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLCConnect
{
    public class SerialInfo
    {
        private static SerialInfo instance;
        public static SerialInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = JsonHelper.LoadSetting<SerialInfo>();
                }
                return instance;
            }
        }
        public SerialInfo()
        {
        }
        public string portName { get; set; } = "COM1";
        public int baudrate { get; set; } = 19200;
        [ReadOnly(true)]
        public StopBits stopBits { get; } = StopBits.One;

        [ReadOnly(true)]
        public int dataBits { get; } = 8;
        public Parity parity { get; } = Parity.None;
        public int writeTimeout { get; set; } = 1;
        public int readTimeout { get; set; } = 1;

        public void Load()
        {
            instance = JsonHelper.LoadSetting<SerialInfo>();
        }
        public void Save()
        {
            JsonHelper.SaveData(instance);
        }

    }

    //public class SerialObj
    //{

    //    public Modbus.Device.ModbusSerialMaster pMaster = null;
    //    public SerialPort pSerialPort = null;
    //    public Thread pThread = null;
    //    public bool pStop = false;
    //    public bool pPause = false;
    //    public SerialObj()
    //    {
    //        pThread = new Thread(run);
    //        pThread.Start();
    //    }

    //    public void run()
    //    {
    //        while (true)
    //        {
    //            if (pStop) return;
    //            try
    //            { 
    //                if (pSerialPort == null) { Thread.Sleep(200); continue; }
    //                if (pSerialPort.IsOpen == false) { pSerialPort.Open(); }
    //                if (pPause) { Thread.Sleep(200); continue; }
    //                ushort[] data = pMaster.ReadHoldingRegisters((byte)1, (ushort)0, 10);
    //                int i = 0;
    //            }
    //            catch (Exception e) { }
    //        }
    //    }
    //    public void updateParameter(string comName = "COM1", int baudRate = 19200, int readTimeout = 2000, int writeTimeout = 2000, StopBits stopBs = StopBits.One)
    //    {
    //        ManagerInfo.Instance.baudrate = baudRate;
    //        ManagerInfo.Instance.portName = comName;
    //        ManagerInfo.Instance.readTimeout = readTimeout;
    //        ManagerInfo.Instance.writeTimeout = writeTimeout;

    //    }

    //    public bool Connect()
    //    {
    //        pSerialPort = new SerialPort();
    //        pSerialPort.BaudRate = ManagerInfo.Instance.baudrate;
    //        pSerialPort.Parity = Parity.None;
    //        pSerialPort.PortName = ManagerInfo.Instance.portName;
    //        pSerialPort.ReadTimeout = ManagerInfo.Instance.readTimeout;
    //        pSerialPort.WriteTimeout = ManagerInfo.Instance.writeTimeout;
    //        pSerialPort.StopBits = ManagerInfo.Instance.stopBits;

    //        pMaster = Modbus.Device.ModbusSerialMaster.CreateRtu(pSerialPort);
    //        return false;
    //    }
    //    public bool Disconnect()
    //    {
    //        return false;
    //    }

    //}
}
