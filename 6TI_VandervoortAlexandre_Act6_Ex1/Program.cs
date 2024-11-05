namespace _6TI_VandervoortAlexandre_Act6_Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Velo velo = new Velo("V6", "Volk", "Rouge", (decimal)1099.9, "pédale", false);
            Voiture voiture = new Voiture("W25", "Volk", "Bleu", (decimal) 15255.99, "automatique", false);

            Console.WriteLine(velo.Affiche());
            Console.WriteLine(voiture.Affiche());
        }
    }
}