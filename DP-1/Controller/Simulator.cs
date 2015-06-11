
using DP_1.Model.Probes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class Simulator
    {
        public Circuit Circuit { get; set; }

        public Simulator()
        {
            this.Circuit = new Circuit();
        }

        public void simulate()
        {
            calculate();
            print();
        }

        public void calculate()
        {
            foreach (Gate g in Circuit.Gates)
            {
                g.result();
            }
        }

        public void print()
        {
            foreach (Gate g in Circuit.Gates)
            {
                Console.WriteLine(g);
            }

            foreach (Probe p in Circuit.Outputs)
            {
                Console.WriteLine(p);
            }
        }

        public string result()
        {
            string resultString = "";
            foreach (Gate g in Circuit.Gates)
            {
                resultString += g + "\n";
                //Console.WriteLine(g);
            }

            foreach (Probe p in Circuit.Outputs)
            {
                resultString += p + "\n";
                //Console.WriteLine(p);
            }

            return resultString;
        }
    }
}
