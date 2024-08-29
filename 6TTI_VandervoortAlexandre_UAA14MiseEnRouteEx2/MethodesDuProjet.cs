namespace _6TTI_VandervoortAlexandre_UAA14MiseEnRouteEx2
{
    internal struct MethodesDuProjet
    {
        public double LireDouble(string message)
        {
            double value;

            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (!double.TryParse(input, out value))
            {
                Console.WriteLine("Je n'ai pas compris ce que vous m'avez donné (" + input + ").");

                input = Console.ReadLine();
            }

            return value;
        }

        public void ChangerCouleurConsole(ConsoleColor CouleurPolice, ConsoleColor CouleurDeFond)
        {
            Console.ForegroundColor = CouleurPolice;
            Console.BackgroundColor = CouleurDeFond;
        }

        public string concatTableau<T>(T[] tableau)
        {
            string concat = "";
            for (int i = 0; i < tableau.Length; i++)
            {
                concat += tableau[i];
                if (i != tableau.Length - 1)
                {
                    concat += ", ";
                }
            }

            return concat;
        }
    }
}
