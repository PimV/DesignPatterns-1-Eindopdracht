using DP_1.Model.Gates;
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

        public Gate createGate(bool A, bool B, GateEnum type)
        {
            Gate gate = GateFactory.createGate(type);
            gate.A = A;
            gate.B = B;
            gate.Count = 0;
            gate.Edges = new List<Gate>();
            return gate;
        }




    }
}
