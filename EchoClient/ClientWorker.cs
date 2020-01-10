using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClient
{
    public class ClientWorker
    {
        public ClientWorker()
        {
            
        }
        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 3002))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = "Add 5 8";

                sw.WriteLine(str);
                sw.Flush();

                string strin = sr.ReadLine();
                Console.WriteLine(strin);
            }

        }
    }
}