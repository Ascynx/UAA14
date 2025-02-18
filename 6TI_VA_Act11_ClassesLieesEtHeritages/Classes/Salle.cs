using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages.Classes
{
    internal class Salle
    {
        private string _id;
        private int _places;

        public string Identifiant { get { return _id; } }
        public int Places { get { return _places; } set { _places = value; } }

        public Salle(string id, int places)
        {
            _id = id;
            _places = places;
        }

        public override string ToString()
        {
            return $"Id: {_id}, places: {_places}";
        }
    }
}
