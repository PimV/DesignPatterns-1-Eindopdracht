using DP_1.Model.Gates;
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

            Probe cout = new Probe();
            Probe s = new Probe();

            bool in1 = true; // A
            bool in2 = true; // B
            bool in3 = true; // Cin

            //A: High, B: High
            //Gate g1 = this.Circuit.createGate(true, true, GateEnum.OR);
            //Gate g2 = this.Circuit.createGate(true, true, GateEnum.AND);
            //Gate g3 = this.Circuit.createGate(false, false, GateEnum.AND);
            //Gate g4 = this.Circuit.createGate(false, false, GateEnum.NOT);
            //Gate g5 = this.Circuit.createGate(false, false, GateEnum.AND);
            //Gate g6 = this.Circuit.createGate(false, false, GateEnum.OR);
            //Gate g7 = this.Circuit.createGate(false, false, GateEnum.NOT);
            //Gate g8 = this.Circuit.createGate(false, false, GateEnum.NOT);
            //Gate g9 = this.Circuit.createGate(false, false, GateEnum.AND);
            //Gate g10 = this.Circuit.createGate(false, false, GateEnum.AND);
            //Gate g11 = this.Circuit.createGate(false, false, GateEnum.OR);

            //A: Low, B: Low
            Gate g1 = this.Circuit.createGate(GateEnum.OR);
            Gate g2 = this.Circuit.createGate(GateEnum.AND);
            Gate g3 = this.Circuit.createGate(GateEnum.AND);
            Gate g4 = this.Circuit.createGate(GateEnum.NOT);
            Gate g5 = this.Circuit.createGate(GateEnum.AND);
            Gate g6 = this.Circuit.createGate(GateEnum.OR);
            Gate g7 = this.Circuit.createGate(GateEnum.NOT);
            Gate g8 = this.Circuit.createGate(GateEnum.NOT);
            Gate g9 = this.Circuit.createGate(GateEnum.AND);
            Gate g10 = this.Circuit.createGate(GateEnum.AND);
            Gate g11 = this.Circuit.createGate(GateEnum.OR);

            //Gate cout = this.Circuit.createGate(false, false, GateEnum.);
            // Gate s = this.Circuit.createGate(false, false, GateEnum.OR);

            List<Gate> gates = new List<Gate>() 
            { 
                g1, 
                g2, 
                g3, 
                g4, 
                g5, 
                g6, 
                g7, 
                g8, 
                g9, 
                g10, 
                g11                
            };

            this.Circuit.linkInput(in1, g1);
            this.Circuit.linkInput(in1, g2);

            this.Circuit.linkInput(in2, g1);
            this.Circuit.linkInput(in2, g2);

            this.Circuit.linkInput(in3, g3);
            this.Circuit.linkInput(in3, g7);
            this.Circuit.linkInput(in3, g10);

            this.Circuit.linkGate(g1, g3);
            this.Circuit.linkGate(g1, g5);

            this.Circuit.linkGate(g2, g4);
            this.Circuit.linkGate(g2, g6);

            this.Circuit.linkGate(g3, g6);

            this.Circuit.linkGate(g4, g5);

            this.Circuit.linkGate(g5, g8);
            this.Circuit.linkGate(g5, g9);

            this.Circuit.linkProbe(g6, cout);

            this.Circuit.linkGate(g7, g9);

            this.Circuit.linkGate(g8, g10);

            this.Circuit.linkGate(g9, g11);

            this.Circuit.linkGate(g10, g11);

            this.Circuit.linkProbe(g11, s);


            int count = 0;
            foreach (Gate g in gates)
            {
                count++;
                Console.WriteLine("NODE: " + count + " " + g);
            }

            Console.WriteLine("S: " + s.Result);
            Console.WriteLine("COut: " + cout.Result);

        }
    }
}
