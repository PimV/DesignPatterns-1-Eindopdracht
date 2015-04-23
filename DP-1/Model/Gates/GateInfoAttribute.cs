using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model.Gates
{
    public class GateInfo : Attribute
    {
        private Type type;

        public GateInfo(Type type)
        {
            this.type = type;
        }

        public Type Type { get { return this.type; } }
    }
}
