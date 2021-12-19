using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Menu
    {

        public static void Launch()
        {
            var garage = new Garage();
            int refId = 0;
            Console.WriteLine("Choir l'action :\nLister 1\nAjouter 2\nSupprimer 3\nModifier 4\nSortir 5");
            var choix = Console.ReadLine();
            choix.Trim();
            if (!String.IsNullOrWhiteSpace(choix) && String.IsNullOrEmpty(choix))
            {
                switch (choix)
                {
                    case "1":
                        var vehicleList = garage.Vehicles.ToString();
                        Console.WriteLine(vehicleList);
                        Launch();
                        break;
                    case "2":
                        Console.WriteLine("Indiquer les infos du vehicule");
                        Console.WriteLine("Indiquer le nom du vehicule");
                        var nom = Console.ReadLine();
                        Console.WriteLine("Indiquer le nombre de roues du vehicule");
                        var type = Console.ReadLine();
                        Console.WriteLine($"Indiquer l'état du vehicule :" +
                            $"\n1{Const.EtatVehicle.bon}\n2{Const.EtatVehicle.moyen}\n{(int)Const.EtatVehicle.mauvais}{Const.EtatVehicle.mauvais} ");
                        var etat = Console.ReadLine();
                        Console.WriteLine("Indiquer la marque du vehicule");
                        var marque = Console.ReadLine();
                        Console.WriteLine("Indiquer le modèle du vehicule");
                        var model = Console.ReadLine();
                        Console.WriteLine("Indiquer le kilometrage du vehicule");
                        var kilometrage = Console.ReadLine();
                        Calcul.CalculId();
                        if (type == "2")
                        {
                            Vehicle vehicle = new TwoWheels(nom, etat, kilometrage, model, marque,refId);
                            garage.AddVehicle(vehicle);
                            Console.WriteLine(garage.Vehicles.Last().ToString());
                        }
                        if (type == "4")
                        {
                            Vehicle vehicle = new FourWheels(nom, etat, kilometrage, model, marque, refId);
                            garage.AddVehicle(vehicle);
                            Console.WriteLine(garage.Vehicles.Last().ToString());
                        }
                        Launch();
                        break;
                    case "3":
                        Console.WriteLine("Indiquer l'id du véhicule à supprimer");
                        var id = Console.ReadLine();
                        id.Trim();
                        DeleteVehicle(id);

                        Console.WriteLine($"Id du véhicule : {id} est incorrect");
                        break;
                    case "4":
                        Console.WriteLine("Indiquer l'id du véhicule à modifier");

                        Launch();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine($"valeur saisie {choix} est incorrecte réessayer");
                Launch();
            }
            
            
        }

        private static void DeleteVehicle(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var garage = new Garage();
                var result = garage.DeleteVehicle(id);
                Console.WriteLine(result);
                Launch();
            }
        }
    }
}
