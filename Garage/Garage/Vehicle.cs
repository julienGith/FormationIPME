using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Vehicle
    {
        private Garage garage;
        
        public Vehicle(string vehiculeName,string state, string kilometrage,string model, string brand, int refid)
        {
            
            IdVehicule = Calcul.CalculId();
            _VehiculeName = vehiculeName;
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

        public int IdVehicule { get; private set; }
        private string _State;
        private string _VehiculeName;
        private string _Model;
        private string _Brand;
        private uint _Kilometrage;


    }
}
