using ChatClient.Net.IO;
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

namespace ChatClient.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnSignInButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }

        private void foo()
        {
            PacketBuilder packetBuilder = new PacketBuilder();
            packetBuilder.WriteOpCode(5);
            packetBuilder.WriteMessage("Привет!");

        }
      
    }
}
