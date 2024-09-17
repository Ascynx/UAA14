using System;
using System.Collections;

namespace _6TI_Vandervoort_OOP_ExLampe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable lampes = new Hashtable();
            List<Interrupteur> interrupteurs = new List<Interrupteur>();

            ConsoleKey continuer = ConsoleKey.Escape;
            ConsoleKey? entree = null;
            while (continuer != ConsoleKey.N)
            {
                //première loop, ce que l'on veut ajouter.

                Console.WriteLine("Voulez vous ajouter une Lampe ou un Interrupteur, ou voulez vous contiNuer??");
                entree = Console.ReadKey(true).Key;
                while (entree != ConsoleKey.L && entree != ConsoleKey.I && entree != ConsoleKey.N)
                {
                    Console.WriteLine("Je n'ai pas compris, merci d'entrer soit L pour une lampe, I pour un interrupteur, ou N pour quitter.");
                    entree = Console.ReadKey(true).Key;
                }

                if (entree == ConsoleKey.N)
                {
                    continuer = ConsoleKey.N;
                }

                if (continuer != ConsoleKey.N)
                {
                    if (entree == ConsoleKey.L)
                    {
                        Console.WriteLine("Quel code voulez vous assignez à cette lampe?");
                        string? code = Console.ReadLine();
                        if (code != null)
                        {
                            //Hex RGB
                            lampes.Add(code, new Lampe(code, 0xFFFFFF));
                        }
                    }
                    else if (entree == ConsoleKey.I)
                    {
                        Console.WriteLine("Quel code voulez vous assignez à cet interrupteur?");
                        string? code = Console.ReadLine();
                        if (code != null)
                        {
                            interrupteurs.Add(new Interrupteur(code));
                        }
                    }
                }
            }
            
            Console.WriteLine("Vous avez " + lampes.Count + " lampes et " + interrupteurs.Count + " interrupteurs.");
            //reset
            continuer = ConsoleKey.Escape;
            String[] lampesCodes = lampes.Keys.Cast<string>().ToArray();
            for (int i = 0; i < interrupteurs.Count; i++)
            {
                Interrupteur interrupteur = interrupteurs[i];
                Console.WriteLine("à quel interrupteur voulez vous lier l'interrupteur: " + interrupteur);
                Console.WriteLine(ConcatTableau(lampesCodes));
                string? entre = Console.ReadLine();
                while (entre == null || !lampesCodes.Contains(entre))
                {
                    Console.WriteLine("veuillez entrer le code de la lampe voulue.");
                    entre = Console.ReadLine();
                }
                interrupteur.SetCodeLampe(entre);
                bool actif = QuestionneUtilisateurBool("Voulez vous activer cet interrupteur?");
                if (interrupteur.GetActif() != actif)
                {
                    //Aurait été mieux si ça fonctionnait comme une HashMap dans java avec le typage mais bon.
                    interrupteur.switchStatut((Lampe) lampes[entre]);
                }
            }
            Console.WriteLine("Voici vos lampes: " + ConcatTableau(lampes.Values.Cast<Lampe>().ToArray()));
            Console.WriteLine("Et vos interrupteurs: " + ConcatTableau(interrupteurs.ToArray()));
            
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
        
        public static bool QuestionneUtilisateurBool(String question)
        {
            return Boolean.Parse(QuestionneUtilisateur(question, (str) => Boolean.TryParse(str, out bool val)));
        }
    }
}