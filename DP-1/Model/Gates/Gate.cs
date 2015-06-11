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
        public int Inputs { get; set; }
        public int MaxInputs { get; set; }
        public List<Gate> Edges { get; set; }

        public Gate()
        {
            MaxInputs = 2;
        }

        public Gate(string name)
        {
            MaxInputs = 2;
            Name = name;
        }

        public void addInput(bool input)
        {
            if (Inputs >= MaxInputs)
            {
                Inputs++;
                throw new MultipleInputException(string.Format("Error trying to add input to gate with name: {0}. " +
                "Inputs found: {1}. Maximum Inputs allowed: {2}.", this.Name, this.Inputs, this.MaxInputs));
            }
            else if (Inputs == 1)
            {
                this.B = input;
                //Inputs++;
            }
            else if (Inputs == 0)
            {
                this.A = input;
                //Inputs++;
            }
            Inputs++;

        }

        public void pipelineResult(bool result)
        {
            //try
            //{
                if (Inputs != MaxInputs)
                {
                    throw new TooFewInputsException(string.Format("Error trying to calculate result on gate with name: {0}. " +
                        "Inputs required: {1}. Inputs given: {2}.", this.Name, this.MaxInputs, this.Inputs));
                }

                this.Result = result;

                foreach (Gate g in Edges)
                {
                    g.addInput(result);
                }
            //}
            //catch (TooFewInputsException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

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
