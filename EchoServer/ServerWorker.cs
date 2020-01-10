using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace EchoServer
{
     public class ServerWorker
     { 
         private List<TcpClient> _socketList;
         private int _sum;
         private double _sumd;

        public ServerWorker()
        {
            _socketList = new List<TcpClient>();
        }

        public int Sum
        {
            get => _sum;
            set => _sum = value;
        }

        public double Sumd
        {
            get => _sumd;
            set => _sumd = value;
        }

        public void Start()
        {
           TcpListener server = new TcpListener(IPAddress.Loopback, 3002);
           server.Start();
           Console.WriteLine("Server");

           while (true)
           {
               TcpClient socket = server.AcceptTcpClient(); // Venter på client

               // Starter en ny tåd
               Task.Run(
                   // Indsætter en metode (delegate)
                   () =>
                   {
                       TcpClient tmpsocket = socket;
                       DoClientMathD(tmpsocket);
                   }
               );
           }
           
        }

        public void DoClientMathD(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = sr.ReadLine().ToLower();
                var strings = str.Split(' ' );
                double i = double.Parse(strings[1],new CultureInfo("da-DK"));
                double j = double.Parse(strings[2], new CultureInfo("da-DK"));

                if (strings[0] == "add")
                {
                    Sumd = i + j;
                }
                else if (strings[0] == "sub")
                {
                    Sumd = i - j;
                }
                else if (strings[0] == "div")
                {
                    Sumd = i / j;
                }
                else if (strings[0] == "mult")
                {
                    Sumd = i * j;
                }
                
                sw.Flush();
                sw.WriteLine("Resultatet er " + Sumd);
            }

            socket?.Close();
        }

        public void DoClientMath(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = sr.ReadLine().ToLower();
                var strings = str.Split(' ' );
                int i = Int32.Parse(strings[1]);
                int j = Int32.Parse(strings[2]);

                if (strings[0] == "add")
                {
                    Sum = i + j;
                }
                else if (strings[0] == "sub")
                {
                    Sum = i - j;
                }
                else if (strings[0] == "div")
                {
                    Sum = i / j;
                }
                else if (strings[0] == "mult")
                {
                    Sum = i * j;
                }
                
                sw.Flush();
                sw.WriteLine("Resultatet er " + Sum);
            }

            socket?.Close();
        }
    }
}