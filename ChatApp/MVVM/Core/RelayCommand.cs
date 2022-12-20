using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.MVVM.Core
{
    /*Интерфейс ICommand — это контракт кода для команд, написанных в .NET для приложений среда выполнения Windows. 
     *Эти команды обеспечивают поведение команд для элементов пользовательского интерфейса, таких как среда выполнения Windows XAML Button и, в частности, .AppBarButton 
     *Если вы определяете команды для приложений среда выполнения Windows, вы используете в основном те же методы, которые вы бы использовали для определения команд для приложения .NET. 
     *Реализуйте команду, определив класс, реализующий ICommand и специально реализующий Execute метод.*/
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Функция которую будем передавать в параметры
        /// </summary>
        private Action<object> execute;

        /// <summary>
        /// Флаг хранит информацию о том, можно ли выполнить функцию или нет
        /// </summary>
        private Func<object, bool> canExecute;


        private string v;
        private Func<object, string> value;



        /// <summary>
        /// Событие CanExecuteChanged вызывается при изменении условий, указывающий, может ли команда выполняться. Для этого используется событие CommandManager.RequerySuggested.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested+=value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }




        /// <summary>
        /// CanExecute(Object) Определяет метод, который определяет, может ли данная команда выполняться в ее текущем состоянии.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Execute(Object)	Определяет метод, вызываемый при вызове данной команды.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            this.execute(parameter);
        }
    }
}
