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
    /// Логика взаимодействия для GiveKeyWindow.xaml
    /// </summary>
    public partial class GiveKeyWindow : Window
    {
        Locker locker = new Locker();
        public GiveKeyWindow(int lockerId)
        {
            InitializeComponent();

            locker = App.context.Locker.FirstOrDefault(x => x.Id == lockerId);

            LockerNameTb.Text = locker.Name;
            LockerRoomNameTb.Text = locker.LockerRoom.Name;
            CustomerCmb.ItemsSource = App.context.User
                .Where(x => x.RoleId == 3)
                .Select(x => x.FullName)
                .ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                locker.UserId = Convert.ToInt32(CustomerCmb.SelectedValue);
                App.context.SaveChanges();
                FeedbackService.Information($"{locker.Name} успешно поменял статус на Занято");
                Close();
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex);
            }
        }
    }
}
