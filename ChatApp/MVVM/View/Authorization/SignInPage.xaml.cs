using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.MVVM.ViewModel.SignInSignUpVM;

namespace ChatClient.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            DataContext = new SignInPageVM();
        }

        private void OnSignUpButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

    }
}
