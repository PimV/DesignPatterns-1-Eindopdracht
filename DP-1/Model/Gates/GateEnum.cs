using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model.Gates
{
    public enum GateEnum
    {
        [GateInfo(typeof(ANDGate))]
        AND,
        [GateInfo(typeof(NOTGate))]
        NOT,
        [GateInfo(typeof(ORGate))]
        OR,
        [GateInfo(typeof(XORGate))]
        XOR
    }
}
