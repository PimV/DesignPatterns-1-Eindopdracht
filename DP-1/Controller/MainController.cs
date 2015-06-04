using DP_1.Model;
using DP_1.Services;
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

        public MainController()
        {
            fileParser = new FileParser();
            simulator = new Simulator();
        }


        public void loadFile(string path)
        {
            fileParser.parse(path);
            simulator.Circuit = fileParser.Circuit;
        }

        public void simulate()
        {
            simulator.simulate();
        }

    }
}
