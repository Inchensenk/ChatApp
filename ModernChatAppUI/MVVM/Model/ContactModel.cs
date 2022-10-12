using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernChatAppUI.MVVM.Model
{
    public class ContactModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }


        public string ImageSource { get; set; }

        public ObservableCollection<MessageModel> Messages { get; set; }

        /// <summary>
        /// Последнее сообщение
        /// </summary>
        public string LastMessage => Messages.Last().Message;
    }
}
