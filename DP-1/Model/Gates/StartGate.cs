using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_1.Model.Gates
{
   public class StartGate : Gate 
    {
        public bool A
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool B
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void compute()
        {
            throw new NotImplementedException();
        }

        public bool result()
        {
            throw new NotImplementedException();
        }


        public List<Gate> Edges { get; set; }

        public void addEdge(Gate g)
        {
            throw new NotImplementedException();
        }
    }
}
