using SDCPervomay.AppData;
using SDCPervomay.Models;
using SDCPervomay.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static SDCPervomay.AppData.SupportModels;

namespace SDCPervomay.View.Pages.ReceptionPages
{
    /// <summary>
    /// Логика взаимодействия для KeysPage.xaml
    /// </summary>
    public partial class KeysPage : Page
    {
        List<LockersModel> lockersModels = new List<LockersModel>();
        List<Locker> lockers = App.context.Locker.ToList();
        public KeysPage()
        {
            InitializeComponent();

            LoadLockers();

            LockerNameCmb.ItemsSource = App.context.LockerRoom
                .ToList();

            LockerNameCmb.SelectedIndex = 0;
            FreeCmb.SelectedItem = FreeLockers;

            LockersLV.ItemsSource = lockersModels;
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            var locker = LockersLV.SelectedItem as LockersModel;
            locker.Status = "Свободно";
            var lockerDb = App.context.Locker.FirstOrDefault(x => x.Id == locker.Id);
            lockerDb.User = null;
            App.context.SaveChanges();
            FeedbackService.Information($"{locker.Name} поменял статус на Свободно");
        }

        private void GiveBtn_Click(object sender, RoutedEventArgs e)
        {
            var locker = LockersLV.SelectedItem as LockersModel;
            if (locker != null)
            {
                GiveKeyWindow giveKeyWindow = new GiveKeyWindow(locker.Id);
                giveKeyWindow.ShowDialog();
            }
            else
            {
                FeedbackService.Error("Вы не выбрали шкафчик!");
            }
        }

        private void FreeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FreeCmb.SelectedItem == FreeLockers)
            {
                LockersLV.ItemsSource = lockersModels.Where(x => x.Status == "Свободно");
            }
            else
            {
                LockersLV.ItemsSource = lockersModels.Where(x => x.Status == "Занято");
            }
        }

        private void LockerNameCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LockersLV.ItemsSource = lockersModels.Where(x => x.LockerRoomId == (int)LockerNameCmb.SelectedValue).ToList();
        }

        private void LoadLockers()
        {
            lockersModels = lockers.Select(locker => new LockersModel
            {
                Id = locker.Id,
                Name = locker.LockerRoom?.Name ?? "Не указано",
                Status = locker.UserId.HasValue ? "Занято" : "Свободно",
                Fullname = locker.User?.FullName ?? "Не занято",
                LockerRoomId = locker.LockerRoom.Id,
            }).ToList();
        }
    }
}
