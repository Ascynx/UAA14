using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal class Questionneur
    {
        public static String QuestionneUtilisateur(String question, Func<String, bool> condition)
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
            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val) && (val >= min && val <= max)));
        }
        
        public static int QuestionneUtilisateurInt(string question)
        {
            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val)));
        }

        public static double QuestionneUtilisateurDouble(String question)
        {
            return Double.Parse(QuestionneUtilisateur(question, (str) => Double.TryParse(str, out double val)));
        }

        public static string QuestionneUtilisateurSimple(String question)
        {
            return QuestionneUtilisateur(question, (str) => true);
        }

        public static bool QuestionneUtilisateurYNQuestion(String question) {
            return new char[]{'y', 'o'}.Contains(QuestionneUtilisateur(question, (str) => {
                string lowerStr = str.ToLower();
                
                //oui: y | yes | oui | o
                //non: n | no | non
                return lowerStr == "y" || lowerStr == "n" || lowerStr == "yes" || lowerStr == "no" || lowerStr == "oui" || lowerStr == "non" || lowerStr == "o";
            }).First());
        }
    }
}
