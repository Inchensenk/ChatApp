using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernChatAppUI.MVVM.Model
{
    public class MessageModel
    {
        public string UserName { get; set; }
        public string UserNameColor { get; set; }
        public string ImageSource { get; set; }
        public string Message{ get; set; }
        public DateTime Time { get; set; }

        /// <summary>
        /// Флаг проверки, было ли сообщение от меня
        /// </summary>
        public bool IsNativeOrigin { get; set; }

        public bool? IsFistMessage { get; set; }

    }
}
