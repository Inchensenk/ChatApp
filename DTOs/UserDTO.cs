using ProtoBuf;

namespace DTOs
{
    [ProtoContract]
    public class UserDTO
    {
        [ProtoMember(1)]
        public int Id { get; private set; }

        [ProtoMember(2)]
        public string NickName { get; private set; } = null!;

        [ProtoMember(3)]
        public string PhoneNumber { get; private set; } = null!;

        [ProtoMember(4)]
        public string FirstName { get; set; } = null!;
        
        [ProtoMember(5)]
        public string LastName { get; set; } = null!;

        public override string ToString() => $"Id: {Id} || NickName: {NickName} || PhoneNumber: {PhoneNumber} || FirstName: {FirstName} || LastName: {LastName}";
    }
}