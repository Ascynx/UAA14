using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes
{
    internal class Utilisateur
    {
        private string _identifiant;
        private string _email;

        public string Identifiant { get { return _identifiant; } }
        public string Email { get { return _email; } set { _email = value; } }

        public Utilisateur(string nom, string email)
        {
            _identifiant = nom;
            _email = email;
        }

        public override string ToString()
        {
            return Identifiant + " (" + _email + ")";
        }
    }
}
