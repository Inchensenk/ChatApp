using ModernChatAppUI.Core;
using ModernChatAppUI.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;

namespace ModernChatAppUI.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; }

        /*Команды*/
        public RelayCommand SendCommand { get; set; }
        //public ContactModel SelectedContact { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                //так как мы используем атрибут [CallerMemberName],
                //то не нужно явно задавать свойство SelectedContact в параметре
                OnPropertyChanged();
            }
        }

        private string _message;
        
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                //так как мы используем атрибут [CallerMemberName],
                //то не нужно явно задавать свойство Message в параметре
                OnPropertyChanged();
            }
            
        }


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    IsFistMessage = false
                }) ;

                Message = "";
            });

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
                    UserName = $"Person {i+1}",
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
                    UserName = $"Alison {i+1}",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/194/194938.png",
                    Messages = Messages
                });
            }
        }
    }
}
