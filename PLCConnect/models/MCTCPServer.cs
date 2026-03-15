//using Modbus.Data;
//using Modbus.Device;
//using Modbus;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace INLINE_AUTO_INTERFACE.Models
//{
//    public class MCTCPServer
//    {
//        string m_ip = "192.168.10.1";
//        int m_port = 25565;
//        object m_lock = new object();
//        Thread m_threadServer;
//        ModbusSerialSlave m_modbusSlaveData = new DefaultSlaveDataStore();
//        //Data m_dataStore = new SlaveDataStore();;

//        public MCTCPServer(string IP, int port)
//        {
//            m_ip = IP;
//            m_port = port;
//            m_threadServer = new Thread(Run);
//            m_threadServer.Start();
//        }

//        public bool Create()
//        {
//            try
//            {
//                //IPAddress ip = IPAddress.Any;
//                IPAddress ip = IPAddress.Parse(m_ip);
//                TcpListener slaveTcpListener = new TcpListener(ip, m_port);
//                slaveTcpListener.Start();
//                Console.WriteLine($"[MCTCPServer] Modbus TCP Server Connected to {m_port}...");
//                var modbusFactory = new ModbusFactory();
//                var slave = modbusFactory.CreateSlave(1, m_modbusSlaveData);
//                var network = modbusFactory.CreateSlaveNetwork(slaveTcpListener);
//                network.AddSlave(slave);

//                // 2️⃣ Chạy lắng nghe client trong luồng riêng
//                var thread = new Thread(() => network.ListenAsync().Wait());
//                thread.Start();

//                Console.WriteLine($"[MCTCPServer] Modbus TCP Server Running on {m_port}...");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"[MCTCPServer] Modbus TCP Server Connect to {m_ip} Fail! {ex}...");
//                return false;
//            }
//            return true;
//        }

//        public void Run()
//        {
//            while (true)
//            {
//                try
//                {
//                    //var holdingRegs = m_modbusSlaveData.HoldingRegisters as DefaultPointSource<ushort>;
//                }
//                catch
//                {

//                }
//                Thread.Sleep(100);
//            }
//        }
//    }
//}
