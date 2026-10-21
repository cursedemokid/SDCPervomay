using ProjectSecurity;
using SDCPervomay.AppData;
using SDCPervomay.Models;
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

namespace SDCPervomay.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ContactsWindow contactsWindow = new ContactsWindow();
            contactsWindow.ShowDialog();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            TechnicalSupportWindow technicalSupportWindow = new TechnicalSupportWindow();
            technicalSupportWindow.ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = App.context.User.FirstOrDefault(x => x.Login == LoginTB.Text);
            if (user != null && PasswordSecurity.Verify(PasswordPB.Password, user.Password))
            {
                if (user.RoleId == 5)
                {
                    App.currentUser = user;
                    FeedbackService.Information($"Добро пожаловать {App.currentUser.FullName}");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {

                }
            }
            else
            {
                FeedbackService.Error("Неправильный логин или пароль! Повторите попытку входа");
            }
        }
    }
}
