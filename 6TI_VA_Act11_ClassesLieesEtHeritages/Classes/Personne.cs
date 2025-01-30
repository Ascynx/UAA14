using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Personne
    {
        private string _nom;
        private string _prenom;
        private string _telephone;
        private string _mail;

        public string Nom { get { return _nom; } }
        public string Prenom { get { return _prenom; } }
        public string Telephone { get { return _telephone; } set { _telephone = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }

        public Personne(string nom, string prenom, string telephone, string mail)
        {
            _nom = nom;
            _prenom = prenom;
            _telephone = telephone;
            _mail = mail;
        }

        public override string ToString()
        {
            return $"Nom: {_nom}, Prenom: {_prenom}, Telephone: {_telephone}, email: {_mail}";
        }
    }
}
