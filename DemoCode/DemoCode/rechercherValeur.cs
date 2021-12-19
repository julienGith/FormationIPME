using System;
namespace DemoCode
{
    public class rechercherValeur
    {
        public static bool RechercheDansTableauOrdonne(int a, int[] tableau)
        {
            int index;
            index = (int)tableau.Length / 2;
            Console.WriteLine("Taille du tableau {0} index {1} valeur {2} recherchée {3}", tableau.Length, index, tableau[index], a);
            if (tableau[index] == a)
            {
                Console.WriteLine("valeur trouvée index {0} = {1}", index, a);
                return true;
            }
            if (index == 1)
            {
                if (tableau.Length == 3)
                {
                    if (tableau[2] == a)
                    {
                        Console.WriteLine("valeur trouvée index 2 = {0})", tableau[2]);
                        return true;
                    }
                }
                if (tableau[0] == a)
                {
                    Console.WriteLine("valeur trouvée index 0 = {0})", tableau[0]);
                    return true;
                }
                Console.WriteLine("valeur recherchée : {0} non trouvée.", a);
                return false;
            }
            if (tableau[index] > a)
            {
                int[] demitableau = tableau[0..index];
                Console.WriteLine("index {0} valeur {1} > valeur recherchée {2}, demitableau {3}",index, tableau[index], a, string.Join(",", demitableau));
                return RechercheDansTableauOrdonne(a, demitableau);
            }
            if (tableau[index] < a)
            {
                int[] demitableau = tableau[index..tableau.Length];
                Console.WriteLine("index {0} valeur {1} < valeur recherchée {2}, demitableau {3}",index, tableau[index], a, string.Join(",", demitableau));
                return RechercheDansTableauOrdonne(a, demitableau);
            }
            Console.WriteLine("valeur recherchée : {0} non trouvée.", tableau[index]);
            return false;
        }
    }
}