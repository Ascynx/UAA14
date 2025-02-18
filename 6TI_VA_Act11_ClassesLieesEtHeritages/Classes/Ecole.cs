using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Ecole
    {
        private string _site;
        private string _codeEcole;
        private List<Departement> _departements;
        private List<Etudiant> _etudiants;

        public string Site { get { return _site; } set { _site = value; } }
        public string CodeEcole { get { return _codeEcole; } }
        public List<Departement> Departements { get { return _departements; } set { _departements = value; } }
        public List<Etudiant> Etudiants { get { return _etudiants; } set { _etudiants = value; } }
        public ImmutableList<Enseignant> Enseignants
        {
            get
            {
                List<Enseignant> enseignants = new();
                for (int i = 0; i < _departements.Count; i++)
                {
                    enseignants.AddRange(_departements[i].Enseignants);
                }

                return enseignants.ToImmutableList();
            }
        }

        public Ecole(string site, string codeEcole)
        {
            _site = site;
            _codeEcole = codeEcole;

            _departements = new List<Departement>();
            _etudiants = new List<Etudiant>();
        }

        public override string ToString()
        {
            return "Site: " + _site + "\n"+
                "Code Ecole: " + _codeEcole + "\n" +
                "Départements: " + Program.PrintList(_departements) + "\n" +
                "élèves: " + Program.PrintList(_etudiants) + "\n";
        }
    }
}
