using System;
using System.Linq;
namespace Bricode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Personne personne = new Personne();
            //Developpeur developpeur = new Developpeur("julien");
            //developpeur.Parler();
            //Personne dev = new Developpeur("julien");
            //dev.Parler();
            //Exception.crash("tes");

            //Menu();
            static void TestPatternFactory(string instruChoisi)
            {
                if (instruChoisi == "1")
                {
                    ViolonFactory violonFactory = new ViolonFactory();
                    IInstrument InstruViolon = violonFactory.CreateInstrument();
                    InstruViolon.MakeSound();
                }
                GuitareFactory guitareFactory = new GuitareFactory();
                IInstrument InstruGuitare = guitareFactory.CreateInstrument();
                InstruGuitare.MakeSound();
            }
            static void Menu()
            {
                int[] tableau = Enumerable.Range(1, 50).ToArray();
                System.Console.WriteLine("<<<<<MENU>>>>>\nrecherche dans un tableau ordonné tapez 1"
                + "\ncompte à rebours tapez 2\ncalcul de somme tapez 3");
                //System.Console.ReadLine();
                var result = System.Console.ReadLine();
                switch (result)
                {
                    case "1":
                        rechercherValeur.RechercheDansTableauOrdonne(12, tableau);
                        Menu();
                        break;
                    case "2":
                        Compteur.décompteur(150);
                        Menu();
                        break;
                    case "3":
                        Calcul.somme(50, 5, out int resultat);
                        System.Console.WriteLine("ça fait {0}", result);
                        Menu();
                        break;
                    case "4":
                    Console.WriteLine($"Choisir un instrument\nViolon : 1\nGuitare : 2");
                    var instru = Console.ReadLine();
                        TestPatternFactory(instru);
                        break;
                }
            }
        }

    }
}
