using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class FourWheels : Vehicle
    {
        public FourWheels(int id, string name, Const.EtatVehicle state, string model, string brand, uint kilometrage) : base(id, name, state, model, brand, kilometrage)
        {
        }
    }
}
