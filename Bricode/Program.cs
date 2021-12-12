using System;
using System.Linq;
namespace Bricode
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            int[] tableau = Enumerable.Range(1, 50).ToArray();
            rechercherValeur.RechercheDansTableauOrdonne(12, tableau);
            System.Console.ReadLine();
            static void Menu()
            {
                Console.WriteLine("Hello World!");
            }
        }

    }
}
