using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Bouteille : Conteneur
    {
        private int _contenance = 75;
        private Ingredient _contenu;

        public Ingredient Contenu { get => _contenu; set => _contenu = value; }

        public Bouteille(Ingredient contenu)
        {
            _contenu = contenu;
        }

        public int GetContenance()
        {
            return _contenance;
        }

        public bool EstVide()
        {
            return _contenu == null || _contenu.Quotient == 0;
        }
    }
}
