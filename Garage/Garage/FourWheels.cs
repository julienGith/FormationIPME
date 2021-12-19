using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class FourWheels : Vehicle
    {
        public FourWheels(string vehiculeName, string state, string kilometrage, string model, string brand, int refid) : base(vehiculeName, state, kilometrage, model, brand, refid)
        {
        }
    }
}
