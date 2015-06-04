using DP_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public abstract class Gate
    {
        public string Name { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }

        public bool? Result { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public List<Gate> Edges { get; set; }

        public Gate() { MaxCount = 2;  }

        public Gate(string name)
        {
            MaxCount = 2;
            Name = name;
        }

        public void addInput(bool input)
        {
            if (Count >= MaxCount)
            {
                Count++;
                throw new MultipleInputException(string.Format("Error trying to add input to gate with name: {0}. " +
                "Inputs found: {1}. Maximum Inputs allowed: {2}.", this.Name, this.Count, this.MaxCount));
            }
            else if (Count == 1)
            {
                this.B = input;
                Count++;
            }
            else if (Count == 0)
            {
                this.A = input;
                Count++;
            }

        }

        public virtual void compute()
        {

        }

        public void pipelineResult(bool result)
        {
            if (Count != MaxCount)
            {
                throw new TooFewInputsException(string.Format("Error trying to calculate result on gate with name: {0}. " +
                    "Inputs required: {1}. Inputs given: {2}.", this.Name, this.MaxCount, this.Count));
            }


            this.Result = result;

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

            return this.Name + "\tA: " + A + " \t\t B: " + B + " \t\t RESULT: " + this.Result;
        }
    }
}
