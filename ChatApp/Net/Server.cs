using ChatClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    internal class Server
    {
        /// <summary>
        /// Предоставляет клиентские подключения для сетевых служб протокола TCP.
        /// </summary>
        TcpClient _client;

        public PacketReader PacketReader;

        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action userDisconnectEvent;
        public Server()
        {
            _client = new();
        }

        public void ConnectToServer(string userName)
        {
            if(!_client.Connected)
            {
                //Локальный IP адрес и порт
                _client.Connect("10.61.140.37", 7891);
                PacketReader = new(_client.GetStream());

                if (!string.IsNullOrEmpty(userName))
                {
                    var connectPacket = new PacketBuilder();

                    connectPacket.WriteOpCode(0);

                    connectPacket.WriteMessage(userName);

                    _client.Client.Send(connectPacket.GetPacketBytes());
                }

                ReadPackets();
            }
        }

        private void ReadPackets()
        {
            /*Класс Task представляет собой одну операцию, которая не возвращает значение и обычно выполняется асинхронно. 
             * Taskобъекты являются одним из центральных компонентов асинхронного шаблона на основе задач, впервые появившиеся в платформа .NET Framework 4. 
             * Поскольку работа, выполняемая Task объектом, обычно выполняется асинхронно в потоке пула потоков, а не синхронно в основном потоке приложения, 
             * можно использовать Status свойство, а также IsCanceledIsCompletedсвойства и IsFaulted свойства, чтобы определить состояние задачи. 
             * Чаще всего лямбда-выражение используется для указания работы, выполняемой задачей.*/
            Task.Run(() => 
            {
                while (true)
                {
                    var opCode = PacketReader.ReadByte();
                    switch (opCode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;

                        case 5:
                            msgReceivedEvent?.Invoke();
                            break;

                        case 10:
                            userDisconnectEvent?.Invoke();
                            break;

                        default:
                            Console.WriteLine("ah yes...");
                            break;
                    }
                }
            });
        }

        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
