using SDCPervomay.AppData;
using SDCPervomay.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SDCPervomay.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                LoginTbl.Text = "Введите логин";
            }
            else
            {

                LoginTbl.Text = "";
            }
        }

        private void PasswordPb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordPb.Password))
            {
                PasswordTbl.Text = "Введите пароль";
            }
            else
            {

                PasswordTbl.Text = "";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = App.context.User
                .Where(x => x.Login == LoginTb.Text)
                .Where(x => x.Password == PasswordPb.Password)
                    .FirstOrDefault();
            if (user != null)
            {
                App.currentUser = user;
                FeedbackService.Information($"Добро пожаловать {user.FullName}!");
                App.mainFrame.Navigate(new ReceptionPage());
            }
            else
            {
                FeedbackService.Error("Вы неправильно ввели логин или пароль попробуйте еще раз!");
            }
        }
    }
}
