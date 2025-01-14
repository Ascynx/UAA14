namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees
{
    internal class Questionneur
    {
        public static string QuestionneUtilisateur(string question, Func<string, bool> condition)
        {
            Console.WriteLine(question);
            string res = Console.ReadLine();
            while (res == null || !condition.Invoke(res))
            {
                Console.WriteLine("Je n'ai pas compris ce que vous avez dit.");
                res = Console.ReadLine();
            }
            return res;
        }
        public static int QuestionneUtilisateurIntMinMax(string question, int min, int max)
        {
            return int.Parse(QuestionneUtilisateur(question, (str) => int.TryParse(str, out int val) && val >= min && val <= max));
        }
        public static int QuestionneUtilisateurInt(string question)
        {
            return int.Parse(QuestionneUtilisateur(question, (str) => int.TryParse(str, out int val)));
        }
        public static double QuestionneUtilisateurDouble(string question)
        {
            return double.Parse(QuestionneUtilisateur(question, (str) => double.TryParse(str, out double val)));
        }
        public static string QuestionneUtilisateurSimple(string question)
        {
            return QuestionneUtilisateur(question, (str) => true);
        }
        public static bool QuestionneUtilisateurYNQuestion(string question)
        {
            return new char[] { 'y', 'o' }.Contains(QuestionneUtilisateur(question, (str) =>
            {
                string lowerStr = str.ToLower();
                //oui: y | yes | oui | o
                //non: n | no | non
                return lowerStr == "y" || lowerStr == "n" || lowerStr == "yes" || lowerStr == "no" || lowerStr == "oui" || lowerStr == "non" || lowerStr == "o";
            }).First());
        }
    }
}