using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        //public List<Vehicle> Vehicles { get { return _vehicles; } set { _vehicles = Vehicles; } }
        internal Vehicle AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            return vehicle;
        }
        internal async Task<bool> SaveListVehicles(List<Vehicle> Vehicles)
        {
            string jsonString = JsonSerializer.Serialize(Vehicles);
            await File.WriteAllTextAsync("ListVehicles.txt", jsonString);
            return true;
        }
        internal async void LoadListVehicles()
        {
            string jsonString = File.ReadAllText(@"ListVehicles.txt");
            Vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonString);
        }
        // to do voir à l'implémenter
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
