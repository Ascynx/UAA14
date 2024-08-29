namespace _6TTI_VandervoortAlexandre_UAA14MiseEnRouteEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodesDuProjet methodes = new();

            Console.WriteLine("Bienvenue dans un programme qui permet de prendre la moyenne de 10 valeurs encodées de suite.");

            ConsoleKey continuer = ConsoleKey.Escape;
            while (continuer != ConsoleKey.N)
            {
                double[] valeurs = new double[10];
                for (int i = 0; i < 10; i++)
                {
                    valeurs[i] = methodes.LireDouble("Entrez le " + (i+1) + "ème nombre");
                }

                double moyenne = 0;
                for (int i = 0; i < 10; i++)
                {
                    moyenne += valeurs[i];
                }

                moyenne /= 10;

                if (moyenne <= 12 && moyenne >= 0)
                {
                    methodes.ChangerCouleurConsole((ConsoleColor) (int) Math.Round(moyenne), ConsoleColor.Black);
                }

                Console.WriteLine("tableau: " + methodes.concatTableau(valeurs));
                Console.WriteLine("moyenne: " + moyenne);

                //remet la couleur "à zero".
                methodes.ChangerCouleurConsole(ConsoleColor.White, ConsoleColor.Black);
                Console.WriteLine("Voulez vous recommencer? Y (oui), N (non)");
                do
                {
                    continuer = Console.ReadKey(true).Key;
                } while (continuer != ConsoleKey.N && continuer != ConsoleKey.Y);
                Console.Clear();
            }
        }
    }
}