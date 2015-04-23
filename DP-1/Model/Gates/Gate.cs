using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public interface Gate
    {
        bool A { get; set; }
        bool B { get; set; }
        void compute();
        bool result();
    }
}
