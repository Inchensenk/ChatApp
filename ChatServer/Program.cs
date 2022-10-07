using ChatServer.Net.IO;
using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static List<Client> _users;
        /// <summary>
        /// Прослушивает подключения от TCP-клиентов сети.
        /// </summary>
        static TcpListener _listener;
        static void Main(string[] args)
        {
            _users = new List<Client>();
            //IP сервера (локальный IP адрес пк) и порт сервера
            _listener = new TcpListener(IPAddress.Parse("10.61.140.37"), 7891);

            //Запускает ожидание входящих запросов на подключение.
            _listener.Start();

            while (true)
            {
                //AcceptTcpClient(): Принимает ожидающий запрос на подключение.
                var client = new Client(_listener.AcceptTcpClient());
                _users.Add(client);
                /*Broadcast the connextion to everyone on the server: Раздать соединение всем на сервере*/
                BroadcastConnection();
            }
        }

        static void BroadcastConnection()
        {
            foreach (var user in _users)
            {
                foreach (var usr in _users)
                {
                    var broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(usr.UserName);
                    broadcastPacket.WriteMessage(usr.UID.ToString());
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }
        public static void BroadcastMessage(string message)
        {
            foreach (var user in _users)
            {
                var msgPacket = new PacketBuilder();
                msgPacket.WriteOpCode(5);
                msgPacket.WriteMessage(message);
                user.ClientSocket.Client.Send(msgPacket.GetPacketBytes());
            }
        }

        public static void BroadcastDisconnect(string uid)
        {
            var disconnectedUser = _users.Where(x => x.UID.ToString() == uid).FirstOrDefault();
            _users.Remove(disconnectedUser);
            foreach (var user in _users)
            {
                var broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(uid);
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }

            BroadcastMessage($"[{disconnectedUser.UserName}] Disconnected!");
        }
    }
}