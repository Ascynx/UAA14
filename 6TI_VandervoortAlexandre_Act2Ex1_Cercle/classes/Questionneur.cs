using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes
{
    internal class Questionneur
    {
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

        public static int QuestionneUtilisateurIntMinMax(string question, int min, int max)
        {
            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val) && (val >= min && val <= max)));
        }

        public static double QuestionneUtilisateurDouble(String question)
        {
            return Double.Parse(QuestionneUtilisateur(question, (str) => Double.TryParse(str, out double val)));
        }
    }
}
