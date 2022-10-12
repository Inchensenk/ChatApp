using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace ChatServer.Net.IO
{
    /// <summary>
    /// Считыватель пакетов
    /// BinaryReader: Считывает примитивные типы данных как двоичные значения в заданной кодировке.
    /// </summary>
    public class PacketReader : BinaryReader
    {
        /// <summary>
        /// Класс NetworkStream предоставляет методы для отправки и получения данных через Stream сокеты в режиме блокировки. 
        /// </summary>
        private NetworkStream _ns;

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="ns"></param>
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }


        public string ReadMessage()
        {
            byte[] msgBuffer;
            var length = ReadInt32();
            msgBuffer = new byte[length];
            _ns.Read(msgBuffer, 0, length);

            var msg = Encoding.UTF8.GetString(msgBuffer);
            return msg;
        }
    }
}
