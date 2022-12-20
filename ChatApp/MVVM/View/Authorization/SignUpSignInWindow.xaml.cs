using ChatClient.MVVM.ViewModel.SignInSignUpVM;
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
using System.Windows.Shapes;

namespace ChatClient.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для SignUpSignInWindow.xaml
    /// </summary>
    public partial class SignUpSignInWindow : Window
    {
        public SignUpSignInWindow()
        {
            InitializeComponent();
            MainFraime.Content=new SignUpSignInWindowVM();
        }



        private void OnBorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Минимизация окна
        /// </summary>
        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnMaximizedButtonClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
