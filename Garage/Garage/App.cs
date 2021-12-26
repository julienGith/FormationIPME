using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class App
    {
        internal static void ReadUserEntry(string userSelection)
        {
            while (String.IsNullOrEmpty(userSelection))
            {
                Console.WriteLine("Saisie incorrecte veuillez réessayer.");
            }
            while (!IsDigit(userSelection))
            {
                Console.WriteLine($"Saisie incorrecte : {userSelection} il faut saisir un chiffre.");
            }

        }
        private static bool IsDigit(string choix)
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
    }
}
