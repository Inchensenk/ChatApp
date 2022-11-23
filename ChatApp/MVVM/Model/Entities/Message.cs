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
        public string UserFrom { get; set; } = null!;
        public string UserTo { get; set; } = null!;
        public int ChatId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
    }
}
