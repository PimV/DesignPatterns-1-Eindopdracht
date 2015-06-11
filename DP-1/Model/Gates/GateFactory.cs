using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DP_1.Services;

namespace DP_1.Model.Gates
{
    public static class GateFactory
    {

        //public static Gate createGate(GateEnum gate)
        //{
        //    var gateAttribute = gate.GetAttribute<GateInfo>();
        //    if (gateAttribute == null)
        //    {
        //        return null;
        //    }
        //    var type = gateAttribute.Type;
        //    Gate result = Activator.CreateInstance(type) as Gate;
        //    return result;
        //}

        //public static Gate createGate(GateEnum gate, bool A, bool B)
        //{
        //    var gateAttribute = gate.GetAttribute<GateInfo>();
        //    if (gateAttribute == null)
        //    {
        //        return null;
        //    }
        //    var type = gateAttribute.Type;
        //    Gate result = Activator.CreateInstance(type) as Gate;
        //    result.A = A;
        //    result.B = B;
        //    return result;
        //}
        public static Gate createGate(GateEnum gate, String name)
        {
            var gateAttribute = gate.GetAttribute<GateInfo>();
            if (gateAttribute == null)
            {
                return null;
            }
            var type = gateAttribute.Type;
            Gate result = Activator.CreateInstance(type) as Gate;
            result.Name = name;
            result.Edges = new List<Gate>();

            return result;
        }


    }
}