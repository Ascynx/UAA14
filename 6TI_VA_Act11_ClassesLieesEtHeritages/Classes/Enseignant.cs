using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Enseignant : Personne
    {
        private DateTime _arrivee;
        private Departement _matiere;
        private List<Cours> _disciplines;

        public DateTime Arrivee { get { return _arrivee; } }
        public Departement Matiere { get { return _matiere; } }
        public List<Cours> Discipline { get { return _disciplines; } set { _disciplines = value; } }


        public Enseignant(string nom, string prenom, string telephone, string mail, DateTime arrivee, Departement matiere) : base(nom, prenom, telephone, mail)
        {
            _arrivee = arrivee;
            _matiere = matiere;
            _disciplines = new List<Cours>();
        }
    }
}
