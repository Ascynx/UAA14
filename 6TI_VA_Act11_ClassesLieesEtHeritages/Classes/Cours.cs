using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Cours
    {
        private string _nom;
        private List<int> _notes;
        private Salle _salle;

        public string Nom { get { return _nom; } }
        public Salle Classe { get { return _salle; } set { _salle = value; } }
        public List<int> Notes { get { return _notes; } set { _notes = value; } }

        public Cours(string nom, Salle salle)
        {
            _nom = nom;
            _salle = salle;
        }

        public int CalculeMoyenne()
        {
            int tot = 0;
            int totDiviseur = _notes.Count;
            for (int i = 0; i < totDiviseur; i++)
            {
                tot += _notes[i];
            }

            return tot / totDiviseur;
        }
    }
}
