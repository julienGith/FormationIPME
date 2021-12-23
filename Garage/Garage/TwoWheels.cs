using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class TwoWheels : Vehicle
    {
        public TwoWheels(int id, string name, Const.EtatVehicle state, string model, string brand, uint kilometrage, uint type) : base(id, name, state, model, brand, kilometrage, type)
        {
        }
    }
}
