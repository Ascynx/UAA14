using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes
{
    internal class Personne
    {
        private double _cash;
        private string _identifiant;

        public double Cash { get { return _cash; } set {  _cash = value; } }
        public string Identifiant { get { return _identifiant; } }

        public Personne(string identifiant)
        {
            _cash = 0;
            _identifiant = identifiant;
        }

        public void Verser(Personne personne, double montant)
        {
            if (montant > _cash)
            {
                return;
            }

            _cash -= montant;
            personne.AjouterArgent(montant);
        }

        public void AjouterArgent(double montant)
        {
            _cash += montant;
        }

        public string AfficheInformations()
        {
            return _identifiant + " a " + _cash + " Euros dans son porte monnaie";
        }
    }
}
