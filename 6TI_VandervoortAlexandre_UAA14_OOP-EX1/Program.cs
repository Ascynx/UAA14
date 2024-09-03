namespace _6TI_VandervoortAlexandre_UAA14_OOP_EX1
{
    internal class Program
    {
        public static string[] races = new string[]
        {
            "Golden Retriever",
            "Bichon",
            "Bulldog",
            "Pug",
            "Shiba Inu"
        };

        static void Main(string[] args)
        {
            ConsoleKey entree = ConsoleKey.NumPad0;
            while (entree != ConsoleKey.NumPad4)
            {
                Chien chien = new(races[Random.Shared.Next(races.Length - 1)], Random.Shared.NextDouble(), Random.Shared.NextDouble() * 10, "Bonne Santé", false);

                Console.WriteLine("Nouveau chien!!:\n" + chien);

                while (entree != ConsoleKey.NumPad4)
                {
                    Console.WriteLine("Que voulez vous faire? Numpad1: Nourrir Le chien, Numpad2: Donner à boire au chien, Numpad3: Faire vieillir le chien, Numpad4: Abandonner le chien");
                    entree = Console.ReadKey(true).Key;
                    while (entree != ConsoleKey.NumPad1 && entree != ConsoleKey.NumPad2 && entree != ConsoleKey.NumPad3 && entree != ConsoleKey.NumPad4)
                    {
                        Console.WriteLine("J'ai pas compris ce que vous vouilliez faire");
                        entree = Console.ReadKey(true).Key;
                    }

                    if (entree == ConsoleKey.NumPad1)
                    {
                        chien.Manger();
                        Console.WriteLine("Vous avez nourrit votre chien.");
                    } else if (entree == ConsoleKey.NumPad2)
                    {
                        chien.Boire();
                        Console.WriteLine("Vous avez donné de l'eau à votre chien.");
                    } else if (entree == ConsoleKey.NumPad3)
                    {
                        chien.Vieillir();
                        Console.WriteLine("Votre chien à vieilli");
                    } else if (entree == ConsoleKey.NumPad4)
                    {
                        Console.WriteLine("Vous venez d'abandonner ce chien. :(");
                        break;
                    }
                    Console.WriteLine("Votre chien:\n" + chien);
                }


            }
        }
    }
}