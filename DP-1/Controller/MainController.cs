using DP_1.Model;
using DP_1.Services;
using DP_1.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Controller
{
    public class MainController
    {
        private FileParser fileParser;
        private Circuit circuit;
        private Simulator simulator;
        public MainWindow mainWindow { get; set; }

        public MainController()
        {
            //fileParser = new FileParser();
            simulator = new Simulator();
        }


        public void loadFile(string path)
        {
            fileParser = new FileParser();
            fileParser.parse(path);
            simulator.Circuit = fileParser.Circuit;
        }

        public void simulate()
        {
            try
            {
                mainWindow.setErrorMessage("");
                simulator.simulate();
                mainWindow.setErrorMessage(simulator.result());
                
            }
            catch (Exception ex)
            {
                mainWindow.setErrorMessage(ex.Message);
            }

            
        }

    }
}
