using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex2
{
    internal class Chat : Animal
    {
        public Chat(string nom, DateTime dateNaissance, int numPuce, decimal taille, bool estConcurrent) : base(nom, dateNaissance, numPuce, taille, estConcurrent)
        {
        }

        public string Miaule()
        {
            return "Resultat: Le miaulement était tellement fort, que vous êtes devenu sourd, perdez l'usage d'une de vos oreilles.";
        }

        public void Ronronne()
        {

        }
    }
}
