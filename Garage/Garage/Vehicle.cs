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
        public Vehicle(int id, string name, Const.EtatVehicle state, string model, string brand, uint kilometrage)
        {
            
            _IdVehicule = id;
            _VehiculeName = name;
            _State = state;
            _Kilometrage = kilometrage;
            _Model = model;
            _Brand = brand;            
        }
        //mininuscule
        private int _IdVehicule;
        private string _VehiculeName;
        private Const.EtatVehicle _State;
        private string _Model;
        private string _Brand;
        private uint _Kilometrage;

        [JsonPropertyName("id")]
        public int Id { get { return _IdVehicule; } }
        [JsonPropertyName("name")]
        public string Name { get { return _VehiculeName; } set { _VehiculeName = value; } }
        [JsonPropertyName("state")]
        public Const.EtatVehicle State { get { return _State; } set { _State = value; } }
        [JsonPropertyName("model")]
        public string Model { get { return _Model; } set { _Model = value; } }
        [JsonPropertyName("brand")]
        public string Brand { get { return _Brand; } set { _Brand = value; } }
        [JsonPropertyName("kilometrage")]
        public uint Kilometrage { get { return _Kilometrage; } set { _Kilometrage = value; } }


    }
}
