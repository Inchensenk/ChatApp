using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    
    public class PacketBuilder
    {
        /// <summary>
        /// Создает поток, резервным хранилищем которого является память.
        /// </summary>
        MemoryStream _ms;
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

        public void WriteMessage(string msg)
        {
            var msgLenght = msg.Length;
            _ms.Write(BitConverter.GetBytes(msgLenght));
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetPacketBytes ()
        {
            return _ms.ToArray();
        }
    }
}
