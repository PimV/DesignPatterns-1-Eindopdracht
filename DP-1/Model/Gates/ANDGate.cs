using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class AND : Gate
    {
        public override bool result()
        {
            bool result = false;
            if (A && B)
            {
                result = true;
            }

            pipelineResult(result);

            return result;

        }

        public override string getKey()
        {
            return "AND";
        }

        public override object Clone()
        {
            
            return new AND();
        }

        public override void show()
        {
            Console.WriteLine("IK BEN EEN AND");
        }
    }
}
