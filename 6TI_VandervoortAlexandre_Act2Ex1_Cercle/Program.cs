using _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            int choix = Questionneur.QuestionneUtilisateurIntMinMax(
                "Quel programme voulez vous lancer? 1: Cercles,\n2: Nombre complexes,\n3: Sandwich Maker,\n4: Banque",
                1,
                4
                );

            switch (choix)
            {
                case 1:
                    {
                        InitProgrammeCercle(ref continuer);
                        break;
                    }
                case 2:
                    {
                        InitProgrammeNombreComplexe(ref continuer);
                        break;
                    }
                case 3:
                    {
                        InitProgrammeSandwichMaker(ref continuer);
                        break;
                    }
                case 4:
                    {
                        InitProgrammeBanque(ref continuer);
                        break;
                    }
                default: break;
            }
        }

        public static void InitProgrammeCercle(ref bool continuer)
        {
            Console.WriteLine("Bienvenue dans ce programme sur le cercle !");

            while (continuer)
            {
                double rayon = Questionneur.QuestionneUtilisateurDouble("Tapez un rayon pour votre cercle.");
                Cercle cercle = new Cercle(rayon);


            }
        }

        public static void InitProgrammeNombreComplexe(ref bool continuer)
        {
            while (continuer)
            {

            }
        }

        public static void InitProgrammeSandwichMaker(ref bool continuer)
        {
            while (continuer)
            {

            }
        }

        public static void InitProgrammeBanque(ref bool continuer)
        {
            while (continuer)
            {

            }
        }
    }
}