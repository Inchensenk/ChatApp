using ChatClient.MVVM.Core;
using ChatClient.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Prism.Commands;
using System.Windows.Controls;

namespace ChatClient.MVVM.ViewModel.SignInSignUpVM
{
    public class SignInPageVM : ObservableObject
    {
        public DelegateCommand SignUpButtonCommand { get; }


        public SignInPageVM()
        {
            SignUpButtonCommand = new DelegateCommand(OnSignUpButtonClick);
        }

        private void OnSignUpButtonClick()
        {
            //NavigationService.Navigate(new SignUpPage());
        }
    }
}
