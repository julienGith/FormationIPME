using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Vehicle
    {
        public Vehicle(string vehiculeName,string state, string kilometrage,string model, string brand, int refid)
        {
            
            IdVehicule = Calcul.CalculId();
            _VehiculeName = vehiculeName;
            State = state;
            kilometrage.Trim();
            if (!String.IsNullOrEmpty(kilometrage))
            {
                try
                {
                    Kilometrage = uint.Parse(kilometrage);

                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.GetType()); 
                }
            }
            Model = model;
            Brand = brand;            
        }

        internal int IdVehicule { get; private set; }
        private string _State;
        private string _VehiculeName;
        private string _Model;
        private string _Brand;
        private uint _Kilometrage;

        public string State { get { return _State; } set { _State = value; } }
        public string VehiculeName { get { return _VehiculeName; } set { _VehiculeName = value; } }
        public string Model { get { return _Model; } set { _Model = value; } }
        public string Brand { get { return _Brand; } set { _Brand = value; } }
        public uint Kilometrage { get { return _Kilometrage; } set { _Kilometrage = value; } }


    }
}
