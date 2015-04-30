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
            if (!A && !B)
            {
                return false;
            }
            return true;
        }

    }
}
