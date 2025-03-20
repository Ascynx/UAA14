using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Cocktail : Conteneur
    {
        private int _contenance = 20;
        private Recette _recette;

        public Recette Formule { get => _recette; set => _recette = value; }

        public Cocktail(Recette recette)
        {
            _recette = recette;
        }

        public Cocktail()
        {
            _recette = new Recette("vide");
        }

        public int GetContenance()
        {
            return _contenance;
        }
    }
}
