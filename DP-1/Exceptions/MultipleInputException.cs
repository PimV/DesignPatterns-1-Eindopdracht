using DP_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Exceptions
{
    public class MultipleInputException : Exception
    {

        public MultipleInputException()
        {
            Console.WriteLine("Multiple inputs found");
        }
        public MultipleInputException(Gate g)
        {
            string message = "Error trying to add input to gate with name: " + g.Name + ". Inputs found: " + g.Inputs + ". Maximum Inputs allowed: " + g.MaxInputs + ".";
            Console.WriteLine(message);
        }



        public MultipleInputException(string message)
            : base(message)
        {

        }
    }
}
