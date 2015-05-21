using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class NOTGate : Gate
    {
        public override bool result()
        {
            bool result = !A;

            pipelineResult(result);

            return result;
        }

    }
}
