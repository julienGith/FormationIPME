using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal abstract class Calcul
    {
        public static int CalculId()
        { 
            var garage = new Garage();
            int refId = 0;
            if (garage.Vehicles == null || garage.Vehicles.Count == 0)
            {
                return refId = 1;
            }
            var vehicle = garage.Vehicles.Last();
            refId = vehicle.IdVehicule;
            return refId++;
        }
    }
}
