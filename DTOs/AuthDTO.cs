using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    [ProtoContract]
    public class AuthDTO
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Login { get; set; } = null!;

        [ProtoMember(3)]
        public string Password { get; set; } = null!;

        public override string ToString() => $"Id: {Id} || Login: {Login} || Password: {Password}";

    }
}
