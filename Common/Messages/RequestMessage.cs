using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    [ProtoContract]
    public class RequestMessage
    {
        [ProtoMember(1)]
        public string Method { get; set; }

        [ProtoMember(2)]
        public byte[]? Data { get; set; }

        /// <summary>
        /// Конструктор по умолчанию нужен для корректной работы ProtoBuf
        /// </summary>
        public RequestMessage()
        {
            //
        }

        public override string ToString() => $"Request: Method {Method}, HasData {Data != null}";
    }
}
