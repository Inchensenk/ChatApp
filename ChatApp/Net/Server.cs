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

        /// <summary>
        /// событие подключения
        /// </summary>
        public event Action connectedEvent;

        /// <summary>
        /// событие получения сообщения
        /// </summary>
        public event Action msgReceivedEvent;

        /// <summary>
        /// событие отключения пользователя от сервера
        /// </summary>
        public event Action userDisconnectEvent;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Server()
        {
            _client = new TcpClient();
        }

        /// <summary>
        /// Подключение к серверу
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        public void ConnectToServer(string userName)
        {
            //Если клиент не подключен
            if(!_client.Connected)
            {
                //Подключение клиента к IP адресу (Localhost 127.0.0.1) и порту
                _client.Connect("127.0.0.1", 7891);
                //GetStream(): Возвращает объект NetworkStream, используемый для отправки и получения данных.
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
                    //код операции
                    var opCode = PacketReader.ReadByte();
                    switch (opCode)
                    {
                        
                        case 1://если код операции равен 1
                            connectedEvent?.Invoke();//то срабатывает событие на подключение клиента
                            break;

                        case 5://если код операции равен 5
                            msgReceivedEvent?.Invoke(); //то срабатывает событие на получение сообщения
                            break;

                        case 10://если код операции равен 10
                            userDisconnectEvent?.Invoke();//то срабатывает событие на отключение клиента от сервера
                            break;

                        default:
                            Console.WriteLine("ah yes...");
                            break;
                    }
                }
            });
        }

        /// <summary>
        /// Отправка сообщения на сервер
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);//присваиваем написанию сообщения код операции равный 5
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());//отправляем массив байт из сообщения
        }
    }
}
