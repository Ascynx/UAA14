using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex4.Classes
{
    public abstract class Employe
    {
        private string _matricule;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;

        public string Matricule { get { return _matricule; } set { _matricule = value; } }
        public string Nom { get { return _nom; } }
        public string Prenom { get { return _prenom; } }
        public DateTime DateNaissance { get { return _dateNaissance; } }

        public Employe(string matricule, string nom, string prenom, DateTime dateNaissance)
        {
            _matricule = matricule;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = dateNaissance;
        }

        public override string ToString()
        {
            return "Matricule: " + _matricule + ", Nom: " + _nom + ", Prenom: " + _prenom + ", Date Naissance: " + _dateNaissance.ToString("dd/mm/yyyy");
        }
    }
}
