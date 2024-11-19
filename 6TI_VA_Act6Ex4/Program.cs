using _6TI_VA_Act6Ex4.Classes;

namespace _6TI_VA_Act6Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directeur.ChiffreAffaire = 1503000;
            Employe[] employes = new Employe[]
            {
                new Ouvrier("o1", "McOuvrier", "Johnny", DateTime.Parse("01-11-1991"), DateTime.Parse("22-01-2021")),
                new Ouvrier("o2", "McOuvrier", "Rony", DateTime.Parse("12-08-1992"), DateTime.Parse("22-01-2021")),
                new Ouvrier("o3", "McOuvrier", "Tony", DateTime.Parse("26-05-1993"), DateTime.Parse("22-01-2021")),
                new Ouvrier("o4", "McOuvrier", "John Jr", DateTime.Parse("13-02-1994"), DateTime.Parse("22-01-2021")),
                new Ouvrier("o5", "WaterMaelon", "Adams", DateTime.Parse("05-10-2002"), DateTime.Parse("12-06-2023")),
                new Cadre("c1", "Cadrus", "Ellen", DateTime.Parse("02-02-1985"), 4),
                new Cadre("c2", "Cadras", "Matt",DateTime.Parse("01-12-1966"), 3),
                new Cadre("c3", "Cadros", "Cedric", DateTime.Parse("29-02-2000"), 2),
                new Directeur("d1", "Dructus", "Emily", DateTime.Parse("12-11-1961"), 3),
                new Directeur("d2", "Cursus", "Thomas", DateTime.Parse("01-06-1954"), 6)
            };

            Console.WriteLine("Année: " + 2024 + ", Chiffre d'affaire cette année: " + 1503000);
            for (int i = 0; i < 10; i++)
            {
                Employe employe = employes[i];
                Console.WriteLine("\n" + employe);
            }
        }
    }
}