using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage
    {
        public List<Vehicle> Vehicles { get; set; }
        internal Vehicle AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            return vehicle;
        }
        internal Vehicle UpDateVehicle(Vehicle vehicle)
        {
            return vehicle;
        }
        internal string DeleteVehicle(string vehicleId)
        {
            vehicleId.Trim();
            if (!String.IsNullOrEmpty(vehicleId))
            {
                uint.TryParse(vehicleId, out uint id);
                var vehicle = Vehicles.FirstOrDefault(v => v.IdVehicule == id);
                var result = Vehicles.Remove(vehicle);
                if (result== true)
                {
                    return "supression réussie";
                }
                return "échec de la suppression";
            }

            return "échec de la suppression";
        }
    }
}
