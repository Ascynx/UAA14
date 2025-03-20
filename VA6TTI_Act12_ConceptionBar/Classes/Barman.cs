using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Barman
    {
        private Bar _bistrot;
        private Shaker _shaker;

        public Bar Bistrot { get => _bistrot; }
        public Shaker Shaker { get => _shaker; }

        public Barman(Bar bistrot, Shaker shaker)
        {
            _bistrot = bistrot;
            _shaker = shaker;
        }

        #nullable enable
        public Cocktail PrepareRecette(Recette recette, Client client, out bool erreur)
        {
            erreur = false;

            _shaker.Lave();
            _shaker.Formule = new Recette(recette.Nom);
            foreach (Ingredient ingredient in recette.Ingredients)
            {
                if (!_bistrot.PeutAvoirIngredient(client.Age, ingredient.Type))
                {
                    erreur = true;
                    break;
                }
                foreach (Bouteille bouteille in _bistrot.Bouteilles)
                {
                    if (bouteille.Contenu.Type == ingredient.Type)
                    {
                        if (ingredient.Quotient * _shaker.GetContenance() / bouteille.GetContenance() > bouteille.Contenu.Quotient)
                        {
                            erreur = true;
                            break;
                        }

                        _shaker.Formule.Ingredients.Add(new Ingredient(ingredient.Type, ingredient.Quotient));

                        //passer de la quantité du shaker à la quantité de la bouteille en fonction du quotient de l'ingrédient. -> bouteille contenance * (ingredient quotient * shaker contenance) / bouteille contenance
                        bouteille.Contenu.Quotient -= ingredient.Quotient * _shaker.GetContenance() / bouteille.GetContenance();
                        break;
                    }
                }
            }

            if (erreur)
            {
                return null;
            }

            _shaker.Melange();
            Cocktail cocktail = new();
            _shaker.Servir(ref cocktail);
            return cocktail;
        }
    }
}
