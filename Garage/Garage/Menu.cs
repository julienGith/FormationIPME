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
            uint km = 0;
            var state = Const.EtatVehicle.bon; 
            garage.LoadListVehicles(garage);
            Console.WriteLine("Choir l'action :\nLister 1\nAjouter 2\nSupprimer 3\nModifier 4\nSortir 5");
            var choix = Console.ReadLine();
            choix.Trim();
            IsDigit(choix);
            if (IsDigit(choix))
            {
                if (!String.IsNullOrEmpty(choix))
                {
                    switch (choix)
                    {
                        case "1":
                            garage.ShowListVehicles(garage);
                            Launch();
                            break;
                        case "2":
                            Console.WriteLine("Indiquer les infos du vehicule");
                            Console.WriteLine("Indiquer le nombre de roues du vehicule");
                            var type = Console.ReadLine().Trim();
                            var nbWheels = IsTypeValid(type);
                            if (!garage.IsThereAnyRoomLeftInGarage(garage))
                            {
                                Console.WriteLine("Plus de place dans le garage.");
                                Launch();
                            }
                            Console.WriteLine("Indiquer le nom du vehicule");
                            var nom = Console.ReadLine().Trim();
                            while (String.IsNullOrEmpty(nom))
                            {
                                Console.WriteLine($"Saisie du nom incorrecte : {nom}");
                                Console.WriteLine("Indiquer le nom du véhicule");
                                nom = Console.ReadLine().Trim();
                            }
                            Console.WriteLine($"Indiquer l'état du vehicule :" +
                                $"\n{Const.EtatVehicle.bon} 1\n{Const.EtatVehicle.moyen} 2\n{Const.EtatVehicle.mauvais} 3");
                            var etat = Console.ReadLine();
                            var result = IsDigit(etat);
                            while (!result)
                            {
                                Console.WriteLine($"Saisie de l'état incorrecte : {etat}");
                                Console.WriteLine($"Indiquer l'état du vehicule :" +
                                $"\n{Const.EtatVehicle.bon} 1\n{Const.EtatVehicle.moyen} 2\n{Const.EtatVehicle.mauvais} 3");
                                etat = Console.ReadLine();
                                result = IsDigit(etat);
                            }
                            switch (IsEtatValid(etat))
                            {

                                case 1: state = Const.EtatVehicle.bon; break;
                                case 2: state = Const.EtatVehicle.moyen; break;
                                case 3: state = Const.EtatVehicle.mauvais; break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Indiquer la marque du vehicule");
                            var marque = Console.ReadLine().Trim();
                            while (String.IsNullOrEmpty(marque))
                            {
                                Console.WriteLine($"Saisie de la marque incorrecte : {marque}");
                                Console.WriteLine("Indiquer la marque du vehicule");
                                marque = Console.ReadLine().Trim();

                            }
                            Console.WriteLine("Indiquer le modèle du vehicule");
                            var model = Console.ReadLine().Trim();
                            while (String.IsNullOrEmpty(model))
                            {
                                Console.WriteLine($"Saisie du modèle incorrecte : {model}");
                                Console.WriteLine("Indiquer la marque du vehicule");
                                model = Console.ReadLine().Trim();

                            }
                            Console.WriteLine("Indiquer le kilometrage du vehicule");
                            var kilometrage = Console.ReadLine().Trim();
                            km = IsKilometrageValid(kilometrage);
                            refId = Calcul.CalculId(garage.Vehicles);
                            
                                if (nbWheels == 2)
                                {
                                    Vehicle vehicle = new TwoWheels(refId, nom, state, model, marque, km);
                                    garage.AddVehicle(vehicle);
                                    garage.SaveListVehicles(garage.Vehicles);
                                    Console.WriteLine($"ID : {vehicle.Id} Nom : {vehicle.Name} Modèle : {vehicle.Model} Marque : {vehicle.Brand} Etat : {vehicle.State} Kilometrage : {vehicle.Kilometrage}");

                                }
                                if (nbWheels == 4)
                                {
                                    Vehicle vehicle = new FourWheels(refId, nom, state, model, marque, km);
                                    garage.AddVehicle(vehicle);
                                    garage.SaveListVehicles(garage.Vehicles);
                                    Console.WriteLine($"ID : {vehicle.Id} Nom : {vehicle.Name} Modèle : {vehicle.Model} Marque : {vehicle.Brand} Etat : {vehicle.State} Kilometrage : {vehicle.Kilometrage}");

                                }
                                Launch();
                            break;
                        case "3":
                            Console.WriteLine("Indiquer l'id du véhicule à supprimer");
                            var id = Console.ReadLine();
                            DeleteVehicle(id,garage);
                            break;
                        case "4":
                            Console.WriteLine("Indiquer l'id du véhicule à modifier");
                            var idUp = Console.ReadLine();
                            UpdateVehicle(idUp,garage);
                            Launch();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                    }
                }
                Launch();
            }
        }

        private static uint IsEtatValid(string? etat)
        {
            var result = uint.TryParse(etat, out uint choixEtat);
            while (!result || String.IsNullOrEmpty(etat))
            {
                Console.WriteLine($"Saisie de l'état incorrecte : {etat}");
                Console.WriteLine("Indiquer l'état du vehicule"
                    +$"\n{Const.EtatVehicle.bon} 1\n{Const.EtatVehicle.moyen} 2\n{Const.EtatVehicle.mauvais} 3");
                etat = Console.ReadLine().Trim();
                IsEtatValid(etat);
            }
            return choixEtat;
        }

        private static uint IsTypeValid(string type)
        {
            var result = uint.TryParse(type, out uint nbWheels);
            while (String.IsNullOrEmpty(type) && nbWheels != 2 | nbWheels != 4 )
            {
                Console.WriteLine($"Saisie incorrecte : {nbWheels}, Le type est soit 2 ou 4");
                Console.WriteLine("Indiquer le nombre de roues du vehicule");
                type = Console.ReadLine().Trim();
                IsTypeValid(type);
            }
            return nbWheels;
        }

        private static uint IsKilometrageValid(string kilometrage)
        {
            var result = uint.TryParse(kilometrage, out uint kilometrageUint);
            while (!result || String.IsNullOrEmpty(kilometrage))
            {
                Console.WriteLine($"Saisie du kilometrage incorrecte : {kilometrage}");
                Console.WriteLine("Indiquer le kilometrage du vehicule");
                kilometrage = Console.ReadLine().Trim();
                IsKilometrageValid(kilometrage);
            }
            return kilometrageUint;

        }

        private static bool IsDigit(string? choix)
        {
            char[] charChoix = choix.ToCharArray();
            if (charChoix.Length > 1)
            {
                var stringChoix = new string(charChoix);
                Console.WriteLine($"Choix saisi : {stringChoix} est incorrect");
                return false;
            }
            if (Char.IsDigit(charChoix[0]) && charChoix.Length == 1)
            {
                return true;
            }
            return true;
        }
        //To do >>>>>> validation
        private static void UpdateVehicle(string idUp, Garage garage)
        {
            idUp.Trim();
            if (!String.IsNullOrEmpty(idUp))
            {
                int.TryParse(idUp, out int idUpInt);
                var vehicle = garage.Vehicles.FirstOrDefault(c=> c.Id == idUpInt);
                if (vehicle == null)
                {
                    Console.WriteLine("Véhicule non trouvé");
                }
                Console.WriteLine("Quelle propriété du véhicule souhaitez vous modifier : " +
                    "\nModifier le nom 1\nModifier le l'état 2\nModifier le modèle 3\nModifier la marque 4\nModifier le kiliométrage 5\n retour au menu 6");
                var choix = Console.ReadLine();
                choix.Trim();
                if (!String.IsNullOrEmpty(choix))
                {
                    switch (choix)
                    {
                        case "1": Console.WriteLine($"Ancien nom : {vehicle.Name} Saisir le nouveau nom :");
                            var nouveauNom = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouveauNom))
                            {
                                garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).Name = nouveauNom;
                                garage.SaveListVehicles(garage.Vehicles);
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
                                        garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).State = Const.EtatVehicle.bon;
                                        Console.WriteLine("Modification de l'état du vehicule effectuée.");
                                        Launch();
                                        break;
                                    case "2":
                                        garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).State = Const.EtatVehicle.moyen;
                                        Console.WriteLine("Modification de l'état du vehicule effectuée.");
                                        Launch();
                                        break;
                                    case "3":
                                        garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).State = Const.EtatVehicle.mauvais;
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
                                garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).Model = nouveauModel;
                            }
                            break;
                        case "4":
                            Console.WriteLine($"Ancien marque : {vehicle.Brand} Saisir la nouvelle marque :");
                            var nouvelleMarque = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouvelleMarque))
                            {
                                garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).Brand = nouvelleMarque;
                            }
                            break;
                        case "5":
                            Console.WriteLine($"Ancien kilométrage : {vehicle.Kilometrage} Saisir la nouvelle marque :");
                            var nouveauKilometrage = Console.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(nouveauKilometrage))
                            {
                                uint.TryParse(nouveauKilometrage, out uint newKm);
                                garage.Vehicles.FirstOrDefault(c => c.Id == idUpInt).Kilometrage = newKm;
                            }
                            break;
                        case "6": Launch();
                            break;
                        default:
                            break;
                    }
                }
                var result = garage.SaveListVehicles;
                Console.WriteLine(result);
                Launch();
            }
        }

        private static void DeleteVehicle(string id,Garage garage)
        {
            id.Trim();

            if (!String.IsNullOrEmpty(id))
            {
                var result = garage.DeleteVehicle(id,garage);
                Console.WriteLine(result);
                Launch();
            }
            Console.WriteLine($"L'Id saisi {id} est incorrect");
            Launch();
        }
    }
}
