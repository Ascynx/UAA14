using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex4.Classes
{
    internal class Directeur : Employe
    {
        private static double _chiffreAffaire;
        public static double ChiffreAffaire
        {
            get { return _chiffreAffaire; }
            set { _chiffreAffaire = value; }
        }

        private double _pourcentage;

        public double Pourcentage
        {
            get
            {
                return _pourcentage;
            }

            set { _pourcentage = value; }
        }

        public double Salaire
        {
            get
            {
                return _chiffreAffaire * (_pourcentage / 100);
            }
        }

        public Directeur(string matricule, string nom, string prenom, DateTime dateNaissance, double pourcentage) : base(matricule, nom, prenom, dateNaissance)
        {
            _pourcentage = pourcentage;
        }

        public override string ToString()
        {
            return base.ToString() + ", chiffre affaire (commun): " + _chiffreAffaire + ", pourcentage: " + _pourcentage + ", salaire: " + Salaire;
        }
    }
}
