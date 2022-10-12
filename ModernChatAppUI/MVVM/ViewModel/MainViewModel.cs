using ModernChatAppUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernChatAppUI.MVVM.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            Messages.Add(new MessageModel 
            { 
                UserName = "Alison",
                UserNameColor="#409AFF",
                ImageSource= "https://cdn-icons-png.flaticon.com/512/194/194938.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin=false,
                IsFistMessage=true
            });

            //затычка: сообщения
            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "Antony",
                    UserNameColor = "#409AFF",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/206/206885.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false
                });
            }

            Messages.Add(new MessageModel
            {
                UserName = "Antony",
                UserNameColor = "#409AFF",
                ImageSource = "https://cdn-icons-png.flaticon.com/512/206/206885.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = false
            });

            //затычка: контакты
            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    UserName = $"Alison {i}",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/194/194938.png",
                    Messages = Messages
                });
            }
        }
    }
}
