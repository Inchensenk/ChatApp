using ChatServer.Net.IO;
using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer // Note: actual namespace depends on the project name.
{
    public class Program
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        static List<Client> _users;
        /// <summary>
        /// Прослушивает подключения от TCP-клиентов сети.
        /// </summary>
        static TcpListener _listener;
        static void Main(string[] args)
        {
            _users = new List<Client>();

            /*IP сервера (локальный IP адрес пк (Localhost 127.0.0.1)) и порт сервера
             * IPAddress: Предоставляет IP-адрес.*/
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891);


            /*Метод Start инициализирует базовый Socketобъект, привязывает его к локальной конечной точке и ожидает входящих попыток подключения.
             *При получении Start запроса на подключение метод помещается в очередь и продолжает прослушивать дополнительные запросы до вызова Stop метода. 
             *Если TcpListener запрос на подключение будет получен после того, как он уже поставил в очередь максимальное количество подключений, 
             *он создаст SocketException запрос на подключение на клиенте.*/

            //Запускает ожидание входящих запросов на подключение.
            _listener.Start();

            while (true)
            {
                //AcceptTcpClient(): Принимает ожидающий запрос на подключение.
                var client = new Client(_listener.AcceptTcpClient());

                //Добавление ного клиента в список пользователей
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