using Microsoft.Win32;
using Modbus.Device;
using System;
using System.IO.Ports;
using System.Threading;

namespace PLCConnect
{
    #region Commmands
    //ReadCoils               đọc coil
    //ReadInputs              đọc discrete input
    //ReadHoldingRegisters    đọc holding register
    //ReadInputRegisters      đọc input register
    //WriteCoil               ghi coil
    //WriteRegister           ghi register
    //WriteCoils              ghi nhiều coil
    //WriteRegisters          ghi nhiều register
    /// <summary>
    /// 
    /// // đọc coil
    /// bool coil = plc.ReadCoil(0);
    /// // đọc nhiều coil
    /// bool[] coils = plc.ReadCoils(0, 10);
    /// // đọc register
    /// ushort[] reg = plc.ReadHoldingRegisters(0, 10);
    /// // ghi coil
    /// plc.WriteCoil(0, true);
    /// // ghi nhiều register
    /// plc.WriteRegisters(0, new ushort[] { 10, 20, 30 });
    /// </summary>
    /// 
    #endregion
    public class ModbusRTUClient
    {
        private SerialPort _serialPort;
        private IModbusSerialMaster _master;
        //private ModbusSerialMaster _master;

        private Thread _pollThread;
        private Thread _reconnectThread;

        private readonly object _lock = new object();

        private bool _running = false;

        private byte mSlaveId;

        public bool IsConnected { get; private set; }

        public event Action<ushort[]> OnDataChanged;

        public int PollInterval = 100;

        public ModbusRTUClient(byte slaveId, string portName, int baudRate, int readTimeout, int writeTimeout)
        {
            mSlaveId = slaveId;

            SerialInfo.Instance.portName = portName;
            SerialInfo.Instance.baudrate = baudRate;
            SerialInfo.Instance.readTimeout = readTimeout;
            SerialInfo.Instance.writeTimeout = writeTimeout;

            _serialPort = new SerialPort(portName)
            {
                BaudRate = SerialInfo.Instance.baudrate,
                DataBits = SerialInfo.Instance.dataBits,
                Parity = SerialInfo.Instance.parity,
                StopBits = SerialInfo.Instance.stopBits,
                WriteTimeout = SerialInfo.Instance.readTimeout,
                ReadTimeout = SerialInfo.Instance.writeTimeout,
            };
            //_serialPort = new SerialPort(portName)
            //{
            //    BaudRate = baudRate,
            //    DataBits = 8,
            //    Parity = Parity.None,
            //    StopBits = StopBits.One,
            //    ReadTimeout = readTimeout,
            //    WriteTimeout = writeTimeout
            //};
        }

        public bool Connect()
        {
            try {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();

                _master = ModbusSerialMaster.CreateRtu(_serialPort);

                _master.Transport.ReadTimeout = _serialPort.ReadTimeout;
                _master.Transport.WriteTimeout = _serialPort.WriteTimeout;
                _master.Transport.Retries = 1;

                IsConnected = true;

                Console.WriteLine($"PLC Connected {_serialPort.PortName}");

                StartPolling();
                StartReconnectMonitor();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("Connect Fail: " + ex.Message);
                IsConnected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            _running = false;

            if (_serialPort.IsOpen)
                _serialPort.Close();

            IsConnected = false;
        }

        // =============================
        // POLLING PLC
        // =============================

        private void StartPolling()
        {
            if (_pollThread != null)
                return;

            _running = true;

            _pollThread = new Thread(() =>
            {
                while (_running) {
                    if (!IsConnected) {
                        Thread.Sleep(1000);
                        continue;
                    }

                    try {
                        ushort[] data = _master.ReadHoldingRegisters(mSlaveId, 0, 10);

                        OnDataChanged?.Invoke(data);
                    }
                    catch {
                        IsConnected = false;
                    }

                    Thread.Sleep(PollInterval);
                }
            });

            _pollThread.IsBackground = true;
            _pollThread.Start();
        }

        // =============================
        // AUTO RECONNECT
        // =============================

        private void StartReconnectMonitor()
        {
            if (_reconnectThread != null)
                return;

            _reconnectThread = new Thread(() =>
            {
                while (true) {
                    if (!IsConnected) {
                        try {
                            Console.WriteLine("Reconnect PLC...");

                            if (_serialPort.IsOpen)
                                _serialPort.Close();

                            Thread.Sleep(1000);

                            _serialPort.Open();

                            _master = ModbusSerialMaster.CreateRtu(_serialPort);

                            IsConnected = true;

                            Console.WriteLine("Reconnect success");
                        }
                        catch {
                            Console.WriteLine("Reconnect fail");
                        }
                    }

                    Thread.Sleep(3000);
                }
            });

            _reconnectThread.IsBackground = true;
            _reconnectThread.Start();
        }

        // =============================
        // READ / WRITE
        // =============================

        public ushort[] ReadHoldingRegisters(ushort startAddress, ushort num)
        {
            lock (_lock) {
                if (!IsConnected)
                    return new ushort[num];

                try {
                    return _master.ReadHoldingRegisters(mSlaveId, startAddress, num);
                }
                catch {
                    IsConnected = false;
                    return new ushort[num];
                }
            }
        }

        public bool WriteRegister(ushort address, ushort value)
        {
            lock (_lock) {
                if (!IsConnected)
                    return false;

                try {
                    _master.WriteSingleRegister(mSlaveId, address, value);
                    return true;
                }
                catch {
                    IsConnected = false;
                    return false;
                }
            }
        }
        
        public bool WriteCoil(ushort address, bool value)
        {
            lock (_lock) {
                if (!IsConnected)
                    return false;

                try {
                    _master.WriteSingleCoil(mSlaveId, address, value);
                    return true;
                }
                catch {
                    IsConnected = false;
                    return false;
                }
            }
        }
        public bool ReadCoil(ushort address)
        {
            // bit 0/1
            lock (_lock) {
                if (!IsConnected)
                    return false;

                try {
                    var data = ReadCoils(address, 1);
                    return data[0];
                }
                catch {
                    IsConnected = false;
                    return false;
                }
            }
        }

        // =============================
        // READ COILS (Function 01)
        // =============================
        public bool[] ReadCoils(ushort startAddress, ushort num)
        {
            lock (_lock) {
                if (!IsConnected)
                    return new bool[num];

                try {
                    return _master.ReadCoils(mSlaveId, startAddress, num);
                }
                catch {
                    IsConnected = false;
                    return new bool[num];
                }
            }
        }

        // =============================
        // READ DISCRETE INPUTS (Function 02)
        // =============================
        public bool[] ReadInputs(ushort startAddress, ushort num)
        {
            lock (_lock) {
                if (!IsConnected)
                    return new bool[num];

                try {
                    return _master.ReadInputs(mSlaveId, startAddress, num);
                }
                catch {
                    IsConnected = false;
                    return new bool[num];
                }
            }
        }

        // =============================
        // READ INPUT REGISTERS (Function 04)
        // =============================
        public ushort[] ReadInputRegisters(ushort startAddress, ushort num)
        {
            lock (_lock) {
                if (!IsConnected)
                    return new ushort[num];

                try {
                    return _master.ReadInputRegisters(mSlaveId, startAddress, num);
                }
                catch {
                    IsConnected = false;
                    return new ushort[num];
                }
            }
        }

        // =============================
        // WRITE MULTIPLE COILS (Function 15)
        // =============================
        public bool WriteCoils(ushort startAddress, bool[] values)
        {
            lock (_lock) {
                if (!IsConnected)
                    return false;

                try {
                    _master.WriteMultipleCoils(mSlaveId, startAddress, values);
                    return true;
                }
                catch {
                    IsConnected = false;
                    return false;
                }
            }
        }

        // =============================
        // WRITE MULTIPLE REGISTERS (Function 16)
        // =============================
        public bool WriteRegisters(ushort startAddress, ushort[] values)
        {
            lock (_lock) {
                if (!IsConnected)
                    return false;

                try {
                    _master.WriteMultipleRegisters(mSlaveId, startAddress, values);
                    return true;
                }
                catch {
                    IsConnected = false;
                    return false;
                }
            }
        }
    }
}