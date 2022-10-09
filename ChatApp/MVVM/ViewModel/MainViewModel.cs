using ChatClient.MVVM.Core;
using ChatClient.MVVM.Model;
using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClient.MVVM.ViewModel
{
    internal class MainViewModel
    {
        /*ObservableCollection Представляет динамическую коллекцию данных, 
        * которая предоставляет уведомления при добавлении или удалении элементов или обновлении всего списка.*/
        /// <summary>
        /// Обозреваемая коллекция из моделей пользователя
        /// </summary>
        public ObservableCollection<UserModel> Users { get; set; }

        /// <summary>
        /// Обозреваемая коллекция из сообщений
        /// </summary>
        public ObservableCollection<string> Messages { get; set; }

        /// <summary>
        /// Команда для подключения к серверу
        /// </summary>
        public RelayCommand ConnectToServerCommand { get; set; }

        /// <summary>
        /// Команда для отправки сообщения
        /// </summary>
        public RelayCommand SendMessageCommand { get; set; }

        /// <summary>
        /// Свойство: Имя пользователя
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Свойство: Сообщение
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// Экземпляр класса Сервер
        /// </summary>
        private Server _server;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            Messages = new ObservableCollection<string>();
            _server = new Server(); 
            
            _server.connectedEvent += UserConnected;//подключение нового пользователя
            _server.msgReceivedEvent += MessageReceived;//получение сообщения
            _server.userDisconnectEvent += RemoveUser;//отключение пользователя

            //Команда подключения к серверу. Если имя пользователя не будет введено в текстовое поле, то команда не выполниться.
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(UserName), o => !string.IsNullOrEmpty(UserName));

            //Команда для отправки сообщения. Если сообщение не будет введено в текстовое поле, то команда не выполниться.
            SendMessageCommand = new RelayCommand(o => _server.SendMessageToServer(Message), o => !string.IsNullOrEmpty(Message));
        }

        private void RemoveUser()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Users.Where(x => x.UID == uid).FirstOrDefault(); 
            user = null!;
            Application.Current.Dispatcher.Invoke(()=> Users.Remove(user));//удаление отключившегося пользователя из обозреваемой коллекции пользователей
        }

        /// <summary>
        /// считывание присланных данных
        /// </summary>
        private void MessageReceived()
        {
            var msg = _server.PacketReader.ReadMessage();//считываем сообщение
            Application.Current.Dispatcher.Invoke(() => Messages.Add(msg));//добавляем в обозреваемую коллекцию сообщений новое сообщение
        }

        //При подключении нового пользователя
        private void UserConnected()
        {
            //создается новый экземпляр пользователя из модели пользователя с именем и идентификатором
            var user = new UserModel
            {
                UserName = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };

            /*Если в коллекции пользователей нет ни одного пользователя у которого есть такой идентификатор,
            то создаем нового пользователя
            
            Application: Предоставляет методы и свойства static для управления приложением, 
            например методы для запуска и остановки приложения, 
            для обработки сообщений Windows и свойства для получения сведений о приложении. 
            Этот класс не наследуется.
            
             */
            if (!Users.Any(x=> x.UID==user.UID))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
