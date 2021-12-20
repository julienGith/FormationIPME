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
            if (!String.IsNullOrEmpty(choix))
            {
                switch (choix)
                {
                    case "1":
                        if (garage.Vehicles != null || garage.Vehicles.Count>0)
                        {
                            foreach (var vehicle in garage.Vehicles)
                            {
                                Console.WriteLine($"ID : {vehicle.IdVehicule} Nom : {vehicle.VehiculeName}");

                            }
                            Launch();
                        }
                        Console.WriteLine("Garage vide");
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
                        refId = Calcul.CalculId();
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
                        DeleteVehicle(id);
                        break;
                    case "4":
                        Console.WriteLine("Indiquer l'id du véhicule à modifier");
                        var idUp = Console.ReadLine();
                        UpdateVehicle(idUp);
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

        private static void UpdateVehicle(string idUp)
        {
            idUp.Trim();
            if (!String.IsNullOrEmpty(idUp))
            {
                int.TryParse(idUp, out int idUpInt);
                var garage = new Garage();
                var vehicle = garage.Vehicles.FirstOrDefault(c=> c.IdVehicule == idUpInt);
                if (vehicle == null)
                {
                    Console.WriteLine("Véhicule non trouvé");
                }
                Console.WriteLine("Quelle propriété du véhicule souhaitez vous modifier : " +
                    "\n1 Modifier le nom \n2Modifier le l'état \n3Modifier le modèle \n4Modifier la marque \n5Modifier le kiliométrage \n6 retour au menu");
                var choix = Console.ReadLine();
                choix.Trim();
                if (!String.IsNullOrEmpty(choix))
                {
                    switch (choix)
                    {
                        case "1": Console.WriteLine($"Ancien nom : {vehicle.VehiculeName} Saisir le nouveau nom :");
                            var nouveauNom = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouveauNom))
                            {
                                garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).VehiculeName = nouveauNom;
                            }
                            break;
                        case "2":
                            // to do à finir
                            Console.WriteLine($"Ancien modèle : {vehicle.State} Saisir le nouvel état :" +
                                $"\n1{ Const.EtatVehicle.bon}\n2{ Const.EtatVehicle.moyen}\n{ (int)Const.EtatVehicle.mauvais}\n{ Const.EtatVehicle.mauvais}");
                            var nouvelEtat = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouvelEtat))
                            {
                                switch (nouvelEtat)
                                {
                                    case "1":
                                        garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).State = Const.EtatVehicle.bon.ToString();
                                        Console.WriteLine("Modification de l'état du vehicule effectuée.");
                                        Launch();
                                        break;
                                    case "2":
                                        garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).State = Const.EtatVehicle.moyen.ToString();
                                        Console.WriteLine("Modification de l'état du vehicule effectuée.");
                                        Launch();
                                        break;
                                    case "3":
                                        garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).State = Const.EtatVehicle.mauvais.ToString();
                                        Console.WriteLine("Modification de l'état du vehicule effectuée.");
                                        Launch();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case "3":
                            Console.WriteLine($"Ancien modèle : {vehicle.Model} Saisir la nouveau modèle :");
                            var nouveauModel = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouveauModel))
                            {
                                garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).Model = nouveauModel;
                            }
                            break;
                        case "4":
                            Console.WriteLine($"Ancien marque : {vehicle.Brand} Saisir la nouvelle marque :");
                            var nouvelleMarque = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouvelleMarque))
                            {
                                garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).Brand = nouvelleMarque;
                            }
                            break;
                        case "5":
                            Console.WriteLine($"Ancien kilométrage : {vehicle.Kilometrage} Saisir la nouvelle marque :");
                            var nouveauKilometrage = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouveauKilometrage))
                            {
                                uint.TryParse(nouveauKilometrage, out uint newKm);
                                garage.Vehicles.FirstOrDefault(c => c.IdVehicule == idUpInt).Kilometrage = newKm;
                            }
                            break;
                        case "6": Launch();
                            break;
                        default:
                            break;
                    }
                }
                    var result = garage.UpDateVehicle(vehicle);
                Console.WriteLine(result);
                Launch();
            }
            throw new NotImplementedException();
        }

        private static void DeleteVehicle(string id)
        {
            id.Trim();

            if (!String.IsNullOrEmpty(id))
            {
                var garage = new Garage();
                var result = garage.DeleteVehicle(id);
                Console.WriteLine(result);
                Launch();
            }
            Console.WriteLine($"L'Id saisi {id} est incorrect");
            Launch();
        }
    }
}
