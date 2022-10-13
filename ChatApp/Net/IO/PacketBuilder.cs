using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    /// <summary>
    /// Класс добавляет данные в поток памяти, который используется для получения байтов для отправки на сервер
    /// По сути осуществляется отправка данных от клиента к серверу и наоборот
    /// </summary>
    public class PacketBuilder
    {
        /// <summary>
        /// Создает поток, резервным хранилищем которого является память.
        /// </summary>
        MemoryStream _ms;

        /// <summary>
        /// Конструктор по умолчанию, создает поток памяти
        /// </summary>
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        /// <summary>
        /// Записывает байт в текущее положение текущего потока.
        /// </summary>
        /// <param name="opCode"></param>
        public void WriteOpCode(byte opCode)
        {
            _ms.WriteByte(opCode);
        }

        /// <summary>
        /// Write(ReadOnlySpan<Byte>): Записывает последовательность байтов, содержащихся в source, 
        /// в текущий поток в памяти и перемещает текущую позицию внутри этого потока в памяти на число записанных байтов.
        /// 
        /// BitConverter Класс: Преобразует базовые типы данных в массив байтов, а массив байтов — в базовые типы данных.
        /// </summary>
        /// <param name="msg">Сообщение</param>
        /*public void WriteMessage(string msg)
        {
            //длинна сообщения
            var msgLenght = msg.Length;

            //получение массива байт
            _ms.Write(BitConverter.GetBytes(msgLenght));

            //преобразование символов из сообщения в последовательность байт
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }*/

        public void WriteMessage(string msg)
        {
            var unicodeMessage = Encoding.UTF8.GetBytes(msg);

            var msgLenght = unicodeMessage.Length;

            _ms.Write(BitConverter.GetBytes(msgLenght));

            _ms.Write(unicodeMessage);
        }



        /// <summary>
        /// получение массива байт пакета
        /// </summary>
        /// <returns>Массив байт</returns>
        public byte[] GetPacketBytes ()
        {
            return _ms.ToArray();
        }
    }
}
