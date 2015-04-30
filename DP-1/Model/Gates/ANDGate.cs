using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class ANDGate : Gate
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
    }
}
