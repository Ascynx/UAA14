using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex4.Classes
{
    internal class Ouvrier : Employe
    {
        private DateTime _arriveeSociete;

        public DateTime ArriveeSociete { get { return _arriveeSociete; } }

        public double Salaire
        {
            get
            {
                return Math.Max(((DateTime.Now.Year - _arriveeSociete.Year) * 100) + 2500, 5000);
            }
        }

        public Ouvrier(string matricule, string nom, string prenom, DateTime dateNaissance, DateTime dateArriveeSociete) : base(matricule, nom, prenom, dateNaissance)
        {
            _arriveeSociete = dateArriveeSociete;
        }

        public override string ToString()
        {
            return base.ToString() + ", date arrivee société: " + _arriveeSociete.ToString("dd/mm/yyyy") + ", salaire: " + Salaire;
        }
    }
}
