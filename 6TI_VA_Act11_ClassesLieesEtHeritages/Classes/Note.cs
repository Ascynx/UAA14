using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Note
    {
        private int _note;
        private Cours _discipline;
        
        public int Points { get { return _note; } set { _note = value; } }
        public Cours Discipline { get { return _discipline; } }

        public Note(int note, Cours discipline)
        {
            _note = note;
            _discipline = discipline;
        }
    }
}
