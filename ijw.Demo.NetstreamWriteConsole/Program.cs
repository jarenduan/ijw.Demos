using ijw.Client.WinConsole;
using ijw.Net.Socket;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ijw.Demo.NetstreamWriteConsole {
    class Program {
        private static string HostName;
        private static int PortNum;
        static void Main(string[] args) {
            HostName = "114.251.23.103";
            //HostName = "10.230.41.8";
            //HostName = "10.230.34.44";
            PortNum = 15210;
            do {
                Console.WriteLine("Run Test");
                for (int i = 0; i < 66; i++) {
                    if (sendData(i.ToString()))
                        ConsoleHelper.WriteLineInColor("成功!");
                    else
                        Console.WriteLine("失败");
                }
            } while (ConsoleHelper.ReadLine("Enter to rerun, Q to exit.") != "q");
        }

        public static bool IsOnline(TcpClient c) {
            return !(!c.Client.Connected || !c.Client.Poll(100, SelectMode.SelectWrite));
        }

        private static bool sendData(string curr) {
            Console.WriteLine("try to send " + curr);
            TcpClient client = null;
            try {
                client = new TcpClient(HostName, PortNum);
                Thread.Sleep(10);
                //if(client.Client.Poll(-1, SelectMode.SelectWrite))
                //    Console.WriteLine("Tcp connected.");
                //else {
                //    Console.WriteLine("TCP not connected.");
                //    return false;
                //}
            }
            catch {
                Console.WriteLine("无法连接, 可能是网络问题/服务器没有开启/地址端口不对!");
                client.CloseIfNotNull();
                return false;
            }
            //if(!IsOnline(client)) {
            //    Console.WriteLine("Tcp disconnected.");
            //    return false;
            //}

            try {
                using (NetworkStream ns = client.GetStream()) {
                    using (MemoryStream mem = new MemoryStream()) {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(mem, curr);
                        long len = mem.Length;
                        byte[] objectLenBytes = BitConverter.GetBytes(len);
                        DebugHelper.WriteLine(string.Format("Write {0} as length header!", objectLenBytes.Length));
                        ns.Write(objectLenBytes, 0, objectLenBytes.Length); //write length as header
                        DebugHelper.Write("Write object...");
                        var b = mem.GetBuffer();
                        ns.Write(b, 0, (int)len);
                        DebugHelper.WriteLine("Done.");
                    }
                    ConsoleHelper.WriteLineInColor("Object transfered.");
                    //if(!IsOnline(client)) {
                    //    Console.WriteLine("Tcp disconnected.");
                    //    return false;
                    //}
                }
            }
            catch {
                Console.WriteLine(" 发送失败.");
                client.CloseIfNotNull();
                return false;
            }

            client.CloseIfNotNull();
            return true;
        }
    }
}
