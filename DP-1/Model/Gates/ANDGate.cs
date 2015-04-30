using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class ANDGate : Gate
    {
        public bool A { get; set; }


        public bool B { get; set; }

        public void compute()
        {
            throw new NotImplementedException();
        }

        public bool result()
        {
            if (A && B)
            {
                return true;
            }
            return false;

        }

        public ANDGate()
        {
            Console.WriteLine("AND gate created");
        }


        public List<Gate> Edges { get; set; }

        public void addEdge(Gate g)
        {
            throw new NotImplementedException();
        }
    }
}
