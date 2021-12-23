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
        public Vehicle(int id, string name, Const.EtatVehicle state, string model, string brand, uint kilometrage, uint type)
        {
            
            _idVehicule = id;
            _vehiculeName = name;
            _state = state;
            _kilometrage = kilometrage;
            _model = model;
            _brand = brand;
            _type = type;
        }
        //mininuscule
        private int _idVehicule;
        private string _vehiculeName;
        private Const.EtatVehicle _state;
        private string _model;
        private string _brand;
        private uint _kilometrage;
        private uint _type;

        [JsonPropertyName("id")]
        public int Id { get { return _idVehicule; } }
        [JsonPropertyName("name")]
        public string Name { get { return _vehiculeName; } set { _vehiculeName = value; } }
        [JsonPropertyName("state")]
        public Const.EtatVehicle State { get { return _state; } set { _state = value; } }
        [JsonPropertyName("model")]
        public string Model { get { return _model; } set { _model = value; } }
        [JsonPropertyName("brand")]
        public string Brand { get { return _brand; } set { _brand = value; } }
        [JsonPropertyName("kilometrage")]
        public uint Kilometrage { get { return _kilometrage; } set { _kilometrage = value; } }
        [JsonPropertyName("type")]
        public uint Type { get { return _type; } set { _type = value; } }

    }
}
