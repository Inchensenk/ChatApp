using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public class ResponseMessage
    {

        [ProtoMember(1)]
        public RequestStatus Status { get; private set; }

        [ProtoMember(2)]
        public string? Context { get; private set; }

        [ProtoMember(3)]
        public byte[]? Data { get; private set; }



        public ResponseMessage()
        {
            //
        }

        public ResponseMessage(RequestStatus status, string? context, byte[]? data)
        {
            Status = status;
            Context = context;
            Data = data;
        }

        public ResponseMessage GetResponseMessage() => new ResponseMessage(Status, Context, Data);

        public override string ToString() => $"Response: Status {Status}, Context {Context ?? "NULL"}, HasData {Data != null}";
    }
}
