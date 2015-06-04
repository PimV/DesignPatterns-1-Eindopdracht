using DP_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Exceptions
{
    public class TooFewInputsException : Exception
    {

        public TooFewInputsException()
        {
            Console.WriteLine("Multiple inputs found");
        }
        public TooFewInputsException(Gate g)
        {
            string message = "Error trying to calculate result on gate with name: " + g.Name + ". Inputs required: " + g.MaxInputs + ". Inputs given: " + g.Inputs + ".";
        }



        public TooFewInputsException(string message)
            : base(message)
        {

        }
    }
}
