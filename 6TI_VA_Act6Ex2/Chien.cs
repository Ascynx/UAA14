using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex2
{
    internal class Chien : Animal
    {
        public Chien(string nom, DateTime dateNaissance, int numPuce, decimal taille, bool estConcurrent) : base(nom, dateNaissance, numPuce, taille, estConcurrent) { }

        public string Aboie()
        {
            return "Votre voisin en a eux marre que votre chien ne fasse qu'aboyer a toute heure et a tiré sur votre chien, perdez 2500 Euro pour la visite chez le vétérinaire.";
        }
    }
}
