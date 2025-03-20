using System;
using System.Collections.Generic;
using VA6TTI_Act12_ConceptionBar.Classes;

namespace VA6TTI_Act12_ConceptionBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            Console.WriteLine("Bienvenue au bar! Quel est votre âge?");
            int age = int.Parse(Console.ReadLine());
            Client client = new Client(age);
            Barman barman = new Barman(bar, new Shaker());

            while (true)
            {
                Console.WriteLine("Que voulez-vous faire?");
                Console.WriteLine("1. Voir le menu");
                Console.WriteLine("2. Commander un cocktail");
                Console.WriteLine("3. Voir la quantité des bouteilles");
                Console.WriteLine("4. Quitter");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherMenu(bar);
                        break;
                    case "2":
                        Recette? recette = null;
                        while (recette == null)
                        {
                            Console.WriteLine("Quel cocktail voulez-vous?");
                            string cocktail = Console.ReadLine();
                            if (cocktail == null)
                            {
                                Console.WriteLine("Cocktail inconnu, veuillez réessayer.");
                            }
                            recette = bar.Menu.Find(r => r.Nom.Equals(cocktail, StringComparison.InvariantCultureIgnoreCase));
                            if (recette == null)
                            {
                                Console.WriteLine("Cocktail inconnu, veuillez réessayer.");
                            }
                        }
                        
                        bool erreur;
                        Cocktail c = barman.PrepareRecette(recette, client, out erreur);
                        Console.WriteLine(
                            erreur
                                ? "Désolé, nous ne pouvons pas vous servir ce cocktail."
                                : "Voici votre cocktail! Bonne dégustation!");
                        break;
                    case "3":
                        AfficherQuantiteBouteilles(bar);
                        break;
                    case "4":
                        Console.WriteLine("Merci de votre visite!");
                        return;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void AfficherMenu(Bar bar)
        {
            Console.WriteLine("Menu des cocktails:");
            foreach (var recette in bar.Menu)
            {
                Console.WriteLine("- " + recette.Nom + ": " + string.Join(", ", recette.Ingredients));
            }
        }

        static void AfficherQuantiteBouteilles(Bar bar)
        {
            Console.WriteLine("Quantité des bouteilles:");
            foreach (var bouteille in bar.Bouteilles)
            {
                Console.WriteLine("- " + bouteille.Contenu.Type + ": " + bouteille.GetContenance() * bouteille.Contenu.Quotient + "cl");
            }
        }
    }
}
