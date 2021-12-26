using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal abstract class Calcul
    {
        internal static int CalculId( List<Vehicle> vehicles)
        { 
            int refId = 0;
            if (vehicles == null || vehicles.Count == 0)
            {
                return refId = 1;
            }
            var vehicle = vehicles.Last();
            refId = vehicle.Id + 1;
            return refId;
        }
    }
}
