using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        //public List<Vehicle> Vehicles { get { return _vehicles; } set { _vehicles = Vehicles; } }
        internal void ShowListVehicles(Garage garage)
        {
            if (garage.Vehicles != null || garage.Vehicles.Count > 0)
            {
                foreach (var vehicle in garage.Vehicles)
                {
                    Console.WriteLine($"ID : {vehicle.Id} Nom : {vehicle.Name} Modèle : {vehicle.Model} Marque : {vehicle.Brand} Etat : {vehicle.State} Kilometrage : {vehicle.Kilometrage}");

                }
            }
            if (garage.Vehicles.Count == 0)
            {
                Console.WriteLine("Garage vide");
            }

        }
        internal async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            string jsonString = File.ReadAllText(@"ListVehicles.txt");
            Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonString);
            Vehicles.Add(vehicle);
            return vehicle;
        }
        internal async Task<bool> SaveListVehicles(List<Vehicle> Vehicles)
        {
            string jsonString = JsonConvert.SerializeObject(Vehicles);
            await File.WriteAllTextAsync("ListVehicles.txt", jsonString);
            return true;
        }
        internal void LoadListVehicles(Garage garage)
        {
            string jsonString = File.ReadAllText(@"ListVehicles.txt");
            if (!String.IsNullOrEmpty(jsonString))
            {
                garage.Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonString);
            }
            else { garage.SaveListVehicles(Vehicles); }
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
                var vehicle = Vehicles.FirstOrDefault(v => v.Id == id);
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
