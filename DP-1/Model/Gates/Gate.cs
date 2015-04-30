using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public abstract class Gate
    {
        public bool A { get; set; }
        public bool B { get; set; }
        public int Count { get; set; }
        public List<Gate> Edges { get; set; }

        public void addInput(bool input)
        {
            if (Count == 0)
            {
                this.A = input;
                Count++;
            }
            else if (Count == 1)
            {
                this.B = input;
                Count++;
            }
        }

        public virtual void compute()
        {

        }

        public void pipelineResult(bool result)
        {
            foreach (Gate g in Edges)
            {
                g.addInput(result);
            }
        }

        public virtual bool result()
        {
            return false;
        }

        public override string ToString()
        {
            return "A: " + A + " \t\t B: " + B + " \t\t RESULT: " + result();
        }
    }
}
