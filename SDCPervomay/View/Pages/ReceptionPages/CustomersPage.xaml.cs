using SDCPervomay.Models;
using SDCPervomay.View.Windows;
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
using static SDCPervomay.AppData.SupportModels;

namespace SDCPervomay.View.Pages.ReceptionPages
{
    /// <summary>
    /// Логика взаимодействия для CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        List<User> customers = App.context.User.Where(x => x.RoleId == 3).ToList();
        List<CustomerModel> filteredCustomers = new List<CustomerModel>();
        List<KidParent> kidParents = App.context.KidParent.ToList();
        public CustomersPage()
        {
            InitializeComponent();

            CategoryCmb.SelectedItem = Kids;

            filteredCustomers = new List<CustomerModel>();

            foreach (var customer in customers
                .Where(x => DateTime.Now.AddYears(-18) < x.DateOfBirth)
                .ToList())
            {
                var parentId = kidParents.FirstOrDefault(x => x.IdKid == customer.Id).IdParent;
                filteredCustomers.Add(new CustomerModel
                {
                    Id = customer.Id,
                    Fullname = customer.FullName,
                    Contact = customers.FirstOrDefault(x => x.Id == parentId).PhoneNumber
                });
            }

            CustomersLv.ItemsSource = filteredCustomers;
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryCmb.SelectedItem == Kids)
            {
                filteredCustomers = new List<CustomerModel>();

                foreach (var customer in customers
                .Where(x => DateTime.Now.AddYears(-18) < x.DateOfBirth)
                .ToList())
                {
                    var parentId = kidParents.FirstOrDefault(x => x.IdKid == customer.Id).IdParent;
                    filteredCustomers.Add(new CustomerModel
                    {
                        Id = customer.Id,
                        Fullname = customer.FullName,
                        Contact = customers.FirstOrDefault(x => x.Id == parentId).PhoneNumber
                    });
                }

                CustomersLv.ItemsSource = filteredCustomers;
            }
            else
            {
                filteredCustomers = new List<CustomerModel>();

                foreach( var customer in customers
                .Where(x => DateTime.Now.AddYears(-18) > x.DateOfBirth)
                .ToList())
                {
                    filteredCustomers.Add(new CustomerModel
                    {
                        Id = customer.Id,
                        Fullname = customer.FullName,
                        Contact = customer.PhoneNumber
                    });
                }

                CustomersLv.ItemsSource = filteredCustomers;
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.ShowDialog
                ();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchTb.Text))
            {
                CustomersLv.ItemsSource = filteredCustomers.Where(x => x.Fullname
                                                           .Contains(SearchTb.Text));
            }
            else
            {
                CustomersLv.ItemsSource = filteredCustomers;
            }
        }
    }
}
