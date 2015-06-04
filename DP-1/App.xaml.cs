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
using DP_1.Services;
using DP_1.Controller;

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
            MainController mainController = new MainController();
            mainWindow.MainController = mainController;
            mainWindow.Show();

            //FileParser parser = new FileParser();
           
            //Simulator s = new Simulator();
            //s.Circuit = parser.Circuit;
            //s.simulate();
          
        }
    }
}
