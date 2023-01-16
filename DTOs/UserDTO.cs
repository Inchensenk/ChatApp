using ProtoBuf;

namespace DTOs
{
    [ProtoContract]
    public class UserDTO
    {
        [ProtoMember(1)]
        public int Id { get; private set; }


    }
}