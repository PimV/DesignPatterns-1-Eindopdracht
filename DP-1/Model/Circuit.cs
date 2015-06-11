
using DP_1.Model.Probes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class Circuit
    {
        public List<Probe> Outputs { get; set; }
        public List<Gate> Gates { get; set; }
        public Gate Root { get; set; }
        public Gate Cin { get; set; }

        public Circuit()
        {
            this.Gates = new List<Gate>();
            this.Root = null;
        }
        public void linkGate(Gate from, Gate to)
        {
            from.Edges.Add(to);
        }

        public void linkProbe(Gate from, Probe to)
        {
            to.Gate = from;
        }

        public void linkInput(bool signal, Gate to)
        {
            to.addInput(signal);
        }
    }
}
