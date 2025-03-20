using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Bar
    {
        private List<Bouteille> _bouteilles;
        private List<Recette> _menu;

        public List<Bouteille> Bouteilles { get => _bouteilles; }
        public List<Recette> Menu { get => _menu; }

        public Bar()
        {
            _bouteilles = new List<Bouteille>();
            ResetCave(ref _bouteilles);
            _menu = new List<Recette>();
            RemplirMenu();
        }

        public bool PeutAvoirIngredient(int age, string typeIngredient)
        {
            return !EstAlcool(typeIngredient) || age >= 18;
        }

        public bool EstAlcool(string ingredient)
        {
            string[] alcools = { "Vodka", "Rhum", "Tequila", "Gin", "Whisky", "Cognac", "Vermouth", "Triple Sec", "Liqueur" };
            return alcools.Contains(ingredient);
        }

        private void RemplirMenu()
        {
            _menu.Add(new Recette("Vodka Sunrise", new List<Ingredient>
            {
                new("Vodka", 0.4f),
                new("Jus de fruit", 0.6f)
            }));

            _menu.Add(new Recette("Rhum & Coke", new List<Ingredient>
            {
                new("Rhum", 0.5f),
                new("Coca", 0.5f)
            }));

            _menu.Add(new Recette("Tequila Sunrise", new List<Ingredient>
            {
                new("Tequila", 0.3f),
                new("Triple Sec", 0.3f),
                new("Jus de citron", 0.4f)
            }));

            _menu.Add(new Recette("Gin Tonic", new List<Ingredient>
            {
                new("Gin", 0.4f),
                new("Tonic", 0.6f)
            }));

            _menu.Add(new Recette("Whisky Water", new List<Ingredient>
            {
                new("Whisky", 0.5f),
                new("Eau", 0.5f)
            }));

            _menu.Add(new Recette("Cognac Vermouth", new List<Ingredient>
            {
                new("Cognac", 0.4f),
                new("Vermouth", 0.6f)
            }));

            _menu.Add(new Recette("Liqueur Soda", new List<Ingredient>
            {
                new("Liqueur", 0.3f),
                new("Soda", 0.7f)
            }));

            _menu.Add(new Recette("Rhum Sirop", new List<Ingredient>
            {
                new("Rhum", 0.4f),
                new("Sirop", 0.6f)
            }));

            _menu.Add(new Recette("Mojito", new List<Ingredient>
            {
                new("Rhum", 0.5f),
                new("Menthe", 0.1f),
                new("Eau gazeuse", 0.4f)
            }));

            _menu.Add(new Recette("Pina Colada", new List<Ingredient>
            {
                new("Rhum", 0.3f),
                new("Lait de coco", 0.3f),
                new("Jus d'ananas", 0.4f)
            }));

            _menu.Add(new Recette("Margarita", new List<Ingredient>
            {
                new("Tequila", 0.4f),
                new("Triple Sec", 0.2f),
                new("Jus de citron vert", 0.4f)
            }));

            _menu.Add(new Recette("Bloody Mary", new List<Ingredient>
            {
                new("Vodka", 0.3f),
                new("Jus de tomate", 0.6f),
                new("Citron", 0.1f)
            }));

            _menu.Add(new Recette("Caipirinha", new List<Ingredient>
            {
                new("Cachaça", 0.5f),
                new("Citron vert", 0.3f),
                new("Sucre", 0.2f)
            }));

            // Recettes sans alcool
            _menu.Add(new Recette("Virgin Mojito", new List<Ingredient>
            {
                new("Menthe", 0.2f),
                new("Eau gazeuse", 0.6f),
                new("Citron vert", 0.2f)
            }));

            _menu.Add(new Recette("Smoothie Fraise", new List<Ingredient>
            {
                new("Fraise", 0.5f),
                new("Banane", 0.3f),
                new("Jus d'orange", 0.2f)
            }));

            _menu.Add(new Recette("Limonade Maison", new List<Ingredient>
            {
                new("Citron", 0.4f),
                new("Eau", 0.5f),
                new("Sucre", 0.1f)
            }));
        }

        public void Restocke()
        {
            _bouteilles.Clear();
            ResetCave(ref _bouteilles);
        }

        private void ResetCave(ref List<Bouteille> bouteilles)
        {
            string[] ingredients = { "Vodka", "Rhum", "Tequila", "Gin", "Whisky", "Cognac", "Vermouth", "Triple Sec", "Liqueur", "Soda", "Jus de fruit", "Eau", "Sirop", "Coca", "Jus de citron", "Tonic", "Jus de citron vert", "Jus d'ananas", "Jus d'orange", "Jus de tomate", "Lait de coco", "Eau gazeuse" };
            for (int i = 0; i < ingredients.Length; i++)
            {
                bouteilles.Add(new Bouteille(new Ingredient(ingredients[i], 1f)));
            }
        }
    }
}
