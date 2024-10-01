using _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            int choix = Questionneur.QuestionneUtilisateurIntMinMax(
                "Quel programme voulez vous lancer?\n1: Cercles,\n2: Nombre complexes,\n3: Sandwich Maker,\n4: Banque",
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

        private static void InitProgrammeCercle(ref bool continuer)
        {
            Console.WriteLine("Bienvenue dans ce programme sur le cercle !");

            while (continuer)
            {
                double rayon = Questionneur.QuestionneUtilisateurDouble("Tapez un rayon pour votre cercle.");
                Cercle cercle = new Cercle(rayon);
                Console.WriteLine(cercle.ToString()); //affiche les attributs
                
                Console.WriteLine("Avec un cercle de rayon diminué de moitié : \n--------------------------------------");

                Cercle cercleMoit = new Cercle(rayon / 2);
                Console.WriteLine(cercleMoit.ToString());
                
                Console.WriteLine("Un autre cercle ? (Tapez sur espace)");
                if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
                {
                    continuer = false;
                }
            }
        }

        private static void InitProgrammeNombreComplexe(ref bool continuer)
        {
            Console.WriteLine("Bienvenue dans ce programme sur les complexes !");
            
            while (continuer)
            {
                int reel = Questionneur.QuestionneUtilisateurInt("Que vaut la partie réelle du complexe de départ?");
                int imaginaire =
                    Questionneur.QuestionneUtilisateurInt("Que vaut la partie imaginaire du complexe de départ?");

                NombreComplexe complexe = new(reel, imaginaire);
                Console.WriteLine("Le premier complexe : " + complexe.AfficheComplexe() + " a pour module : " + complexe.AfficheComplexe());
                
                Console.WriteLine("Merci d'entrer un second complexe");
                reel = Questionneur.QuestionneUtilisateurInt("Que vaut la partie réelle du second complexe?");
                imaginaire = Questionneur.QuestionneUtilisateurInt("Que vaut la partie imaginaire du second complexe?");

                NombreComplexe complexe2 = new(reel, imaginaire);
                
                Console.WriteLine("Le second complexe est: " + complexe2.AfficheComplexe());
                
                complexe.Ajoute(complexe2);
                Console.WriteLine("Après addition avec le second, le premier complexe devient: " + complexe.AfficheComplexe());
                
                Console.WriteLine("Voulez vous faire un autre test? (Tapez sur espace)");
                if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
                {
                    continuer = false;
                }
            }
        }

        
        private static void InitProgrammeSandwichMaker(ref bool continuer)
        {
            Console.WriteLine("Bienvenue dans le concepteur de sandwich.");
            SandwichMaker maker = new();
            while (continuer)
            {
                Console.WriteLine("Tapez sur espace pour créer un sandwich. (Autre touche pour quitter.)\n");
                if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
                {
                    continuer = false;
                }
                else
                {
                    Console.WriteLine(maker.ComposeSandwich());
                }
            }
        }

        private static void InitProgrammeBanque(ref bool continuer)
        {
            Console.WriteLine("Bienvenue dans le gestionnaire de porte monnaie.");
            while (continuer)
            {
                String nom = Questionneur.QuestionneUtilisateurSimple("Quel est le nom du premier compte?");
                Personne pers = new(nom);
                pers.AjouterArgent(Questionneur.QuestionneUtilisateurDouble("Quelle est la balance de " + pers.Identifiant + "?"));
                
                String nom2 = Questionneur.QuestionneUtilisateurSimple("Quel est le nom du second compte?");
                Personne pers2 = new(nom2);
                pers2.AjouterArgent(Questionneur.QuestionneUtilisateurDouble("Quelle est la balance de " + pers2.Identifiant + "?"));
                
                Console.WriteLine("\n=============================================\n");
                Console.WriteLine("\t" + pers.AfficheInformations());
                Console.WriteLine("\t" + pers2.AfficheInformations());

                Console.WriteLine("\n\n=====Test de transaction=====\n");
                double val = Questionneur.QuestionneUtilisateurDouble(pers.Identifiant + ", combien voulez vous transférer à " + pers2.Identifiant + "?");
                if (val > pers.Cash)
                {
                    Console.WriteLine("\nDésolé " + pers.Identifiant + ", vous n'avez pas assez d'argent sur votre compte pour ce transfert.");
                }
                else
                {
                    pers.Verser(pers2, val);
                    Console.WriteLine("Transféré " + val +"€ de " + pers.Identifiant + " vers " + pers2.Identifiant);
                }
                
                Console.WriteLine("\n=============================================\n");
                Console.WriteLine("\t" + pers.AfficheInformations());
                Console.WriteLine("\t" + pers2.AfficheInformations());
                
                Console.WriteLine("\n\n=====Test de transaction 2=====\n");
                val = Questionneur.QuestionneUtilisateurDouble(pers2.Identifiant + ", combien voulez vous transférer à " + pers.Identifiant + "?");
                if (val > pers2.Cash)
                {
                    Console.WriteLine("\nDésolé " + pers2.Identifiant + ", vous n'avez pas assez d'argent sur votre compte pour ce transfert.");
                }
                else
                {
                    pers.Verser(pers, val);
                    Console.WriteLine("Transféré " + val +"€ de " + pers2.Identifiant + " vers " + pers.Identifiant);
                }
                
                Console.WriteLine("\n=============================================\n");
                Console.WriteLine("\t" + pers.AfficheInformations());
                Console.WriteLine("\t" + pers2.AfficheInformations() + "\n");
                
                Console.WriteLine("Voulez vous continuer? (Tapez sur espace)");
                if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
                {
                    continuer = false;
                }
            }
        }
    }
}