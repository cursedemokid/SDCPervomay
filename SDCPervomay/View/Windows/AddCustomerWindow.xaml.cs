using SDCPervomay.AppData;
using System;
using System.Linq;
using System.Windows;

namespace SDCPervomay.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();

            GenderCmb.ItemsSource = App.context.Gender
                .Select(x => x.Name)
                .ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var users = App.context.User.ToList();

            var fullname = FullnameTb.Text;

            string[] parts = fullname.Split(' ');

            string lastName = parts.Length > 0 ? parts[0] : "";
            string firstName = parts.Length > 1 ? parts[1] : "";
            string middleName = parts.Length > 2 ? parts[2] : "";

            try
            {
                users.Add(new Models.User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    FullName = fullname,
                    DateOfBirth = DateOfBirthDp.SelectedDate ?? DateTime.Now,
                    RoleId = 3,
                    GenderId = Convert.ToInt32(GenderCmb.SelectedValue)
                });

                App.context.SaveChanges();
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
