using System;
using System.ComponentModel;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWorker worker = new ClientWorker();
            worker.Start();

            Console.ReadKey();
        }
    }
}
