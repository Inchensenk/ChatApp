using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; } = null!;
        public string ChatLogo { get; set; } = null!;
        public int ChatId { get; set; }
    }
}
