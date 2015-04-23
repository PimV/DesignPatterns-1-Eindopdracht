using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class Edge
    {
        public Gate Parent { get; set; }
        public Gate Child { get; set; }

        public Edge()
        {

        }
    }
}
