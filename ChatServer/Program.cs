using System;
using System.Net;
using System.Net.Sockets;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static TcpListener _listener;
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("10.61.140.37"), 7891);
            _listener.Start();

            var client = _listener.AcceptTcpClient();
            Console.WriteLine("Client has connected!");
        }
    }
}