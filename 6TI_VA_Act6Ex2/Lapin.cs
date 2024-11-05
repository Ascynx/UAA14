using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex2
{
    internal class Lapin : Animal
    {
        private decimal _tailleOreille;

        public decimal TailleOreille { get { return _tailleOreille; } set { _tailleOreille = value; } }
        public Lapin(string nom, DateTime dateNaissance, int numPuce, decimal taille, bool estConcurrent, decimal tailleOreille) : base(nom, dateNaissance, numPuce, taille, estConcurrent)
        {
            _tailleOreille = tailleOreille;
        }

        public string Saute()
        {
            return "Resultat: En ré-atterissant, votre lapin a écrasé une voiture, passer 20 ans en prison sans passer par la case départ.";
        }
    }
}
