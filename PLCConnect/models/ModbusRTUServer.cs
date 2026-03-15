using System;
using System.IO.Ports;
using System.Threading;
using Modbus.Data;
using Modbus.Device;

namespace PLCConnect
{
    public class ModbusRTUServer
    {
        private SerialPort _port;
        private ModbusSerialSlave _slave;
        private DataStore _dataStore;

        private Thread _serverThread;
        private bool _running;

        public bool IsRunning => _running;
        DiscreteCollection CoilDiscretes;
        DiscreteCollection InputDiscretes;
        RegisterCollection HoldingRegisters;
        RegisterCollection InputRegisters;
        public ModbusRTUServer(byte slaveId, string portName, int baudrate)
        {

            //CoilDiscretes = new DiscreteCollection(1000),
            //    InputDiscretes = new DiscreteCollection(1000),
            //    HoldingRegisters = new RegisterCollection(1000),
            //    InputRegisters = new RegisterCollection(1000)
            _port = new SerialPort(portName)
            {
                BaudRate = baudrate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };

            _dataStore = new DataStore();
            //_dataStore = new DataStore
            //{ CoilDiscretes = new DiscreteCollection()
            //};
            _slave = ModbusSerialSlave.CreateRtu(slaveId, _port);
            _slave.DataStore = _dataStore;
        }

        // ============================
        // START SERVER
        // ============================
        public void Start()
        {
            if (_running)
                return;

            if (!_port.IsOpen)
                _port.Open();

            _running = true;

            _serverThread = new Thread(ServerLoop);
            _serverThread.IsBackground = true;
            _serverThread.Start();

            Console.WriteLine("Modbus RTU Server Started");
        }

        // ============================
        // SERVER LOOP
        // ============================
        private void ServerLoop()
        {
            try {
                _slave.Listen();
            }
            catch (Exception ex) {
                Console.WriteLine("Server error: " + ex.Message);
            }

            _running = false;
        }

        // ============================
        // STOP SERVER
        // ============================
        public void Stop()
        {
            _running = false;

            if (_port.IsOpen)
                _port.Close();
        }

        // ============================
        // HOLDING REGISTER
        // ============================

        public ushort GetHoldingRegister(int addr)
        {
            return _dataStore.HoldingRegisters[addr];
        }

        public void SetHoldingRegister(int addr, ushort value)
        {
            _dataStore.HoldingRegisters[addr] = value;
        }

        // ============================
        // INPUT REGISTER
        // ============================

        public ushort GetInputRegister(int addr)
        {
            return _dataStore.InputRegisters[addr];
        }

        public void SetInputRegister(int addr, ushort value)
        {
            _dataStore.InputRegisters[addr] = value;
        }

        // ============================
        // COIL
        // ============================

        public bool GetCoil(int addr)
        {
            return _dataStore.CoilDiscretes[addr];
        }

        public void SetCoil(int addr, bool value)
        {
            _dataStore.CoilDiscretes[addr] = value;
        }

        // ============================
        // DISCRETE INPUT
        // ============================

        public bool GetInput(int addr)
        {
            return _dataStore.InputDiscretes[addr];
        }

        public void SetInput(int addr, bool value)
        {
            _dataStore.InputDiscretes[addr] = value;
        }
    }
}