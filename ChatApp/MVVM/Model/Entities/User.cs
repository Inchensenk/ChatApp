using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        
    }
}
