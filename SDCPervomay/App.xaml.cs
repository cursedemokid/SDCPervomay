using SDCPervomay.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SDCPervomay
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SDCPervomayEntities context = new SDCPervomayEntities();
        public static User currentUser = new User();
        public static Frame mainFrame = new Frame();
    }
}
