using CE_Juin25_POO_VandervoortAlexandre.Classes;
using PoolEscrime;

namespace CE_Juin25_POO_VandervoortAlexandre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey continuer = ConsoleKey.Escape;

            Console.WriteLine("Bienvenue dans cette application de gestion de pool d'escrime.");
            while (continuer != ConsoleKey.N)
            {
                Console.WriteLine("Choisissez une pool entre 1 et 3:");
                int poolNumber;
                while (!int.TryParse(Console.ReadLine(), out poolNumber) || poolNumber < 1 || poolNumber > 3)
                {
                    Console.WriteLine("Veuillez entrer un numéro de pool valide (1, 2 ou 3) :");
                }
                Pool pool = ElementsFournis.GetPool(poolNumber);
                if (pool == null)
                {
                    Console.WriteLine($"Aucune pool trouvée pour le numéro {poolNumber}. Veuillez réessayer.");
                    continue;
                }

                Console.WriteLine("Veuillez choisir une option :");
                Console.WriteLine("1. Est-ce que la pool est terminée?");
                Console.WriteLine("2. Afficher les participants de la pool");
                Console.WriteLine("3. Afficher le récapitulatif des matchs");
                Console.WriteLine("4. Afficher La Performance des Tireurs");
                Console.WriteLine("5. Quitter l'application");
                ConsoleKey choix = Console.ReadKey(true).Key;
                Console.Write("\n\n");

                pool.CalculPerformancesParTireur();
                switch (choix)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            if (pool.Terminee())
                            {
                                Console.WriteLine("La pool est terminée.");
                            }
                            else
                            {
                                Console.WriteLine("La pool n'est pas terminée.");
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Console.WriteLine(pool.AfficherParticipantsPool());
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            Console.WriteLine(pool.AfficherRecapitulatifCompletMatchs());
                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            Console.WriteLine(pool.AfficherPerformanceTireurs());

                            Console.WriteLine("Voulez vous enregistrer ces données dans la BDD?\n\tEnter = Oui");
                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                            {
                                pool.UpdateBDDPerformances();
                            }
                            break;
                        }
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            continuer = ConsoleKey.N;
                            break;
                        }
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
