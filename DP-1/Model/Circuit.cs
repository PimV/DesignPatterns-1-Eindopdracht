using DP_1.Model.Gates;
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

        public List<Gate> Gates { get; set; }
        public Gate Root { get; set; }
        public Gate Cin { get; set; }

        public Circuit()
        {
            this.Gates = new List<Gate>();
            this.Root = null;
        }

        public void addGate(Gate gate)
        {
            this.Gates.Add(gate);
        }
        public void linkGate(Gate from, Gate to)
        {
            from.Edges.Add(to);
            to.Edges.Add(from);
        }

        public void linkProbe(Gate from, Probe to)
        {
            to.Gate = from;
        }

        public void linkInput(bool signal, Gate to)
        {
            to.addInput(signal);
        }

        public Gate createGate(GateEnum type)
        {
            Gate gate = GateFactory.createGate(type);
            //gate.A = false;
            //gate.B = false;
            gate.Count = 0;
            gate.Edges = new List<Gate>();
            return gate;
        }




    }
}
