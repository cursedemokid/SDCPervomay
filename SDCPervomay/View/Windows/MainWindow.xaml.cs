using SDCPervomay.AppData;
using SDCPervomay.View.Pages;
using SDCPervomay.View.Pages.ReceptionPages;
using SDCPervomay.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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

namespace SDCPervomay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock currentTbl = new TextBlock();
        public MainWindow()
        {
            InitializeComponent();

            currentTbl.TextDecorations = null;
            currentTbl = ScheduleTbl;
            ScheduleTbl.TextDecorations = TextDecorations.Underline;
            MainFrame.Navigate(new SchedulePage());
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

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = CustomersTbl;
            CustomersTbl.TextDecorations = TextDecorations.Underline;
            MainFrame.Navigate(new CustomersPage());
        }

        //расписание
        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = ScheduleTbl;
            ScheduleTbl.TextDecorations = TextDecorations.Underline;
            MainFrame.Navigate(new SchedulePage());
        }

        private void TextBlock_MouseDown_4(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBlock_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoBack)
            {
                MainFrame.NavigationService.GoBack();
                currentTbl.TextDecorations = null;
            }
            
        }

        private void TextBlock_MouseDown_6(object sender, MouseButtonEventArgs e)
        {
            if(FeedbackService.Question("Вы уверены, что хотите выйти?") == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                Close();
            }
        }
    }
}
