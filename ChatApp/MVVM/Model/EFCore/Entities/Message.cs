using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string FromNumber { get; set; } = null!;
        public string MessageText { get; set; } = null!;
        public DateTime SendDateTime { get; set; }

        public int ConversationId { get; set; }
        public Conversation? Conversation { get; set; }
    }
}
