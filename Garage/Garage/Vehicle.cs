using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage
{
    internal class Vehicle
    {
        public Vehicle(int id, string name, string state, string model, string brand, string kilometrage)
        {
            
            _IdVehicule = id;
            _VehiculeName = name;
            _State = state;
            kilometrage.Trim();
            if (!String.IsNullOrEmpty(kilometrage))
            {
                try
                {
                    _Kilometrage = uint.Parse(kilometrage);

                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.GetType()); 
                }
            }
            _Model = model;
            _Brand = brand;            
        }

        private int _IdVehicule;
        private string _VehiculeName;
        private string _State;
        private string _Model;
        private string _Brand;
        private uint _Kilometrage;

        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get { return _IdVehicule; } }
        [JsonInclude]
        [JsonPropertyName("name")]
        public string Name { get { return _VehiculeName; } set { _VehiculeName = value; } }
        [JsonInclude]
        [JsonPropertyName("state")]
        public string State { get { return _State; } set { _State = value; } }
        [JsonInclude]
        [JsonPropertyName("model")]
        public string Model { get { return _Model; } set { _Model = value; } }
        [JsonInclude]
        [JsonPropertyName("brand")]
        public string Brand { get { return _Brand; } set { _Brand = value; } }
        [JsonInclude]
        [JsonPropertyName("kilometrage")]
        public uint Kilometrage { get { return _Kilometrage; } set { _Kilometrage = value; } }


    }
}
