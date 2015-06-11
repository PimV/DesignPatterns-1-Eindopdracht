using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model
{
    public class NAND : Gate
    {

        public override bool result()
        {
            if (A && B)
            {
                return false;
            }

            return true;
        }

        public override string getKey()
        {
            return "NAND";
        }

        public override object Clone()
        {
            return new NAND();
        }

        public override void show()
        {
            Console.WriteLine("IK BEN EEN NAND");
        }
    }
}
