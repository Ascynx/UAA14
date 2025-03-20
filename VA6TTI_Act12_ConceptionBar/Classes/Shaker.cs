using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Shaker : Conteneur
    {
        private int _contenance = 20;

        private Recette _formule;

        private bool _melangee;

        public Recette Formule { get => _formule; set => _formule = value; }
        public bool EstMelangee { get => _melangee; }

        public Shaker()
        {
            _formule = null;
            _melangee = false;
        }

        public void Melange()
        {
            _melangee = true;
        }

        public void Lave()
        {
            _formule = null;
        }

        public void Servir(ref Cocktail cocktail)
        {
            cocktail.Formule = _formule;
            _formule = null;
            _melangee = false;
        }

        public int GetContenance()
        {
            return _contenance;
        }
    }
}
