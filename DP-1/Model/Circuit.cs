using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class Circuit
    {

        public List<Gate> Gates { get; set; }
        public Gate Root { get; set; }

        public Circuit()
        {
            this.Gates = new List<Gate>();
            this.Root = null;
        }

        public void createRoot()
        {

        }

        public void createGate(bool A, bool B)
        {

        }

        public void addGate(Gate gate)
        {

        }
    }
}
