using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DP_1.View;
using DP_1.Model.Gates;
using DP_1.Model;

namespace DP_1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


            Simulator s = new Simulator();
        }
    }
}
