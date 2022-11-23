using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model.Entities
{
    public class UserChatLink
    {
        public string UserId { get; set; } = null!;
        public string ChatId { get; set; } = null!;
    }
}
