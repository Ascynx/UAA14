namespace _6TI_VandervoortAlexandre_UAA14_OOP_EX1
{
    internal class Program
    {
        public static readonly string[] _noms = new string[]
        {
            "Haribo",
            "Rio",
            "Sputnik",
            "Rover",
            "Tux",
            "Arass",
            "Monster",
            "Carmo",
            "Ansell",
            "Calvados",
            "Bomber",
            "Ardon",
            "Breyn",
            "Tambur"
        };

        public static readonly string[] _races = new string[]
        {
            "Golden Retriever",
            "Bichon",
            "Bulldog",
            "Pug",
            "Shiba Inu",
            "Aïdi",
            "Airedale Terrier",
            "Affenpinscher",
            "Akita américain",
            "Akita Inu",
            "American Staffordshire Terrier",
            "Ancien chien d'arrêt danois"
        };

        static void Main(string[] args)
        {
            ConsoleKey entree = ConsoleKey.NumPad0;
            Chien[] kennel = new Chien[3];
            int index = 0;
            while (entree != ConsoleKey.NumPad4)
            {
                Chien chien = GenereChienRandom();

                Console.WriteLine("Nouveau chien!!:\n" + chien);

                while (entree != ConsoleKey.NumPad4)
                {
                    Console.WriteLine("Que voulez vous faire?\nNumpad1: Nourrir Le chien,\nNumpad2: Donner à boire au chien,\nNumpad3: Faire vieillir le chien,\nNumpad4: Abandonner le chien");
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
                        entree = ConsoleKey.NumPad0;
                        if (index >= kennel.Length)
                        {
                            index = 0;
                        }
                        kennel[index++] = chien;
                        Console.WriteLine("Vous venez d'abandonner ce chien. :(");
                        break;
                    }

                    if (chien.GetEtat() == "Mort")
                    {
                        break;
                    }
                    Console.WriteLine("Votre chien:\n" + chien);
                }

                Console.WriteLine("Voulez vous continuer? Num4: Quitter");
                entree = Console.ReadKey(true).Key;
            }

            //remplit le reste de chiens random.
            for (int i = index; i < kennel.Length; i++)
            {
                kennel[i] = GenereChienRandom();
                for (int j = 0; j < (int) Math.Round((double) Random.Shared.Next(1, 5)); j++)
                {
                    kennel[i].VieillirSkipCheck();
                }
            }

            Console.WriteLine("kennel:\n" + ConcatTableau(kennel));
            Console.WriteLine("Age moyen:\n" + AgeMoyenTableau(kennel));
            Console.ReadKey(true);
        }

        public static string ConcatTableau<T>(T[] tableau)
        {
            string concat = "";
            for (int i = 0; i < tableau.Length; i++)
            {
                concat += tableau[i];
                if (i != tableau.Length - 1)
                {
                    concat += ",\n";
                }
            }

            return concat;
        }

        public static int AgeMoyenTableau(Chien[] chiens)
        {
            int ageTot = 0;
            for (int i = 0; i < chiens.Length;i++)
            {
                ageTot += chiens[i].GetAge();
            }

            return ageTot / chiens.Length;
        }

        public static Chien GenereChienRandom()
        {
            return new(_noms[Random.Shared.Next(_noms.Length - 1)], _races[Random.Shared.Next(_races.Length - 1)], Random.Shared.NextDouble(), Random.Shared.NextDouble() * 10, "Bonne Santé", false);
        }
    }
}