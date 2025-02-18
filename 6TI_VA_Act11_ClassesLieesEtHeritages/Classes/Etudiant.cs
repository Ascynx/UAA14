using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Etudiant : Personne
    {
        private int _anneeArrivee;
        private List<Note> _notes;

        public int AnneeArrivee { get { return _anneeArrivee; } }
        public List<Note> Notes { get { return _notes; } set { _notes = value; } }

        public Etudiant(string nom, string prenom, string telephone, string mail, int anneeArrivee) : base(nom, prenom, telephone, mail)
        {
            _anneeArrivee = anneeArrivee;
            _notes = new List<Note>();
        }

        public int CalculeMoyenneGenerale()
        {
            int tot = 0;
            int denoCommun = _notes.Count;
            for (int i = 0; i < _notes.Count; i++)
            {
                tot += _notes[i].Points;
            }
            return (tot / denoCommun);
        }

        public string GetMatieresNotees()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _notes.Count; i++)
            {
                sb.Append(_notes[i].Discipline + ", ");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $", Annee d'Arrivee: {_anneeArrivee}, Moyenne générale: {CalculeMoyenneGenerale()}";
        }
    }
}
