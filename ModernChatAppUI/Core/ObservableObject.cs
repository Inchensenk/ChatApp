﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModernChatAppUI.Core
{
    /* 1) Не нужно реализовывать INotifyPropertyChanged, если нужно обновлять пользовательский интерфейс из пользовательского интерфейса, а источником привязки является обычный старый обьект clr
       2) Если планируется обновлять значения из кода позади, то реализация INotifyPropertyChanged нужна */
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// атрибут [CallerMemberName] позволяет получить метод или имя свойства вызывающего метода
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
