using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    internal class Server
    {
        TcpClient _client;
        public Server()
        {
            _client = new();
        }

        public void ConnectToServer()
        {
            if(!_client.Connected)
            {
                //Локальный IP адрес и порт
                _client.Connect("10.61.140.37", 7891);
            }
        }
    }
}
