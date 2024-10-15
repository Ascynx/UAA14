namespace I2P624_VandervoortAlexandre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FeuDeSignalisation[] feux = new FeuDeSignalisation[2];

            feux[0] = new FeuDeSignalisation(0, "1001", false);
            feux[1] = new FeuDeSignalisation(0, "007", false);

            Console.WriteLine("\nEtat et couleurs des feux : ");
            Console.WriteLine("-----------------------------------");
            
            Console.WriteLine(feux[0].AfficheEtat());
            Console.WriteLine(feux[1].AfficheEtat());


            //passe l'état
            feux[0].ChangeEtat();
            feux[1].ChangeEtat();


            Console.WriteLine("\nFaire passer le 007 à l'orange : ");
            Console.WriteLine("-----------------------------------");

            feux[1].ChangeCouleur(1);
            Console.WriteLine(feux[1].AfficheEtat());


            Console.WriteLine("\nFeu clignotant : ");
            Console.WriteLine("-----------------------------------");

            feux[1].Clignote(5);


            Console.WriteLine("\nChangement d'état : ");
            Console.WriteLine("-----------------------------------");

            for (int i = 0; i < 5; i++)
            {
                int x = 5-(i+3);
                if (x < 0)
                {
                    x = 3 + x;
                }

                feux[0].ChangeCouleur(x); //2, 1, 0, 2, 1
                Console.WriteLine(feux[0].AfficheCouleur());
            }
        }
    }
}