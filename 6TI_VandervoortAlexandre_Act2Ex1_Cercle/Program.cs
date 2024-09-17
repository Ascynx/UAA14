namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans ce programme sur le cercle !");
            
            bool continuer = true;
            while (continuer)
            {
                double rayon = QuestionneUtilisateurDouble(("Taper un rayon pour votre cercle.");
                Cercle cercle = new Cercle(rayon);
            }
        }

        public static String QuestionneUtilisateur(String question, Func<String, bool> condition)
        {
            Console.WriteLine(question);
            string res = Console.ReadLine();

            while (res == null || !condition.Invoke(res))
            {
                Console.WriteLine("Je n'ai pas compris ce que vous avez dis.");
                res = Console.ReadLine();
            }

            return res;
        }

        public static double QuestionneUtilisateurDouble(String question)
        {
            return Double.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val)));
        }
    }
}