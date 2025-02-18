using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Departement
    {
        private string _matiere;
        private List<Enseignant> _enseignants;
        private List<Cours> _disciplines;

        public string Matiere { get { return _matiere; } }
        public List<Enseignant> Enseignants { get { return _enseignants; } set { _enseignants = value; } }
        public List<Cours> Cours { get { return _disciplines; } set { _disciplines = value; } }

        public Departement(string matiere)
        {
            _matiere = matiere;
            _enseignants = new List<Enseignant>();
            _disciplines = new List<Cours>();
        }

        public override string ToString()
        {
            return "Matiere: " + _matiere + "\n" +
                "\tEnseignants: " + Program.PrintList(_enseignants) + "\n" +
                "\tDisciplines: " + Program.PrintList(_disciplines) + "\n";
        }
    }
}
