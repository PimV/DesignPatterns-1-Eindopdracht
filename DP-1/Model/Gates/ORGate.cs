using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class ORGate : Gate
    {

        public override bool result()
        {
            bool result = true;

            if (!A && !B)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            pipelineResult(result);

            return result;
        }

    }
}
