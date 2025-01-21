using I5_6TTIUAA14_Vandervoort.Classes;

namespace I5_6TTIUAA14_Vandervoort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //init
            PaintBallGun[] guns = new PaintBallGun[20];
            for (int i = 0; i < guns.Length; i++)
            {
                guns[i] = new PaintBallGun();
            }

            Console.WriteLine("Quel est votre pseudonyme?");
            string pseudo = Console.ReadLine();
            Joueur joueur = new(pseudo, guns[0]);

            bool continuer = true;

            Console.WriteLine("Bienvenue dans ce jeu de tir ... Vous démarrez avec 30 balles");
            Console.WriteLine("=============================================================");
            while (continuer)
            {
                if (joueur.MyPaintBallGun.ChargeurEstVide())
                {
                    Console.WriteLine("Attention votre chargeur est vide");
                }
                Console.WriteLine("");

                Console.WriteLine("Espace pour tirer,");
                Console.WriteLine("r pour recharger,");
                Console.WriteLine("v pour voir combien il reste de munitions en poche et dans le chargeur,");
                Console.WriteLine("+ pour reprendre des munitions,");
                Console.WriteLine("q pour quitter");


                Console.Write("===> ");
                ConsoleKey entree = Console.ReadKey().Key;
                Console.WriteLine("");
                switch(entree)
                {
                    case (ConsoleKey.Spacebar):
                        {
                            if (joueur.Tire())
                            {
                                Console.WriteLine("Tir effectué !");
                            } else
                            {
                                Console.WriteLine("Vous n'avez pas assez de munitions pour tirer");
                            }
                            break;
                        }
                    case (ConsoleKey.R):
                        {
                            Console.WriteLine(joueur.Recharger());
                            break;
                        }
                    case (ConsoleKey.V):
                        {
                            Console.WriteLine(joueur.VerifiePoche());
                            break;
                        }
                    case (ConsoleKey.OemPlus):
                    case (ConsoleKey.Add):
                        {
                            byte pre = joueur.NbCartouchesEnPoche;
                            joueur.NbCartouchesEnPoche = 30;

                            Console.WriteLine($"Reprise de {30 - pre} cartouches effectuée vous avez un total de {joueur.NbCartouchesEnPoche} cartouches en poche.");
                            break;
                        }
                    case (ConsoleKey.Q):
                        {
                            continuer = false;
                            break;
                        }
                }
            }
        }
    }
}
