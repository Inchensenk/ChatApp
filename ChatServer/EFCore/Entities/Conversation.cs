using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.EFCore.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public string ConversationName { get; set; } = null!;
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Message> Messages { get; set; }

        public Conversation()
        {
            Messages = new List<Message>();
        }
    }
}
