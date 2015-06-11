using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class NOT : Gate
    {
        public NOT()
        {
            MaxInputs = 1;
        }
        public override bool result()
        {
            bool result = !A;

            pipelineResult(result);

            return result;
        }

        public override string getKey()
        {
            return "NOT";
        }

        public override object Clone()
        {
            return new NOT();
        }

        public override void show()
        {
            Console.WriteLine("IK BEN EEN NOT");
        }

    }
}
