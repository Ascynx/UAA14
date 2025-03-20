using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Recette
    {
        private string _nom;
        private List<Ingredient> _ingredients;

        public string Nom { get => _nom; set => _nom = value; }
        public List<Ingredient> Ingredients { get => _ingredients; }

        public Recette(string nom, List<Ingredient> ingredients)
        {
            _nom = nom;
            _ingredients = ingredients;
        }

        public Recette(string nom)
        {
            _nom = nom;
            _ingredients = new List<Ingredient>();
        }
    }
}
