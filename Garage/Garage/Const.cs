using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Const
    {
        public const int Id = 0;
        public enum EtatVehicle
        {
            bon,
            moyen,
            mauvais
        }
        public enum MarqueVehicle
        {
            Peugeot,
            Renault,
            Citroën,
            Honda
        }
        private enum Option
        {
            Lister,
            Ajouter,
            Supprimer,
            Modifier

        }
        internal enum ExpectedAnswerType
        {
            String,
            Char,
            Int,
        }
    }
}
