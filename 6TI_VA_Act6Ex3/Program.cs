using _6TI_VA_Act6Ex3.Classes;

namespace _6TI_VA_Act6Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de figures descendant d'un parallelepipede\n");

            Parallelepipede[] figures = new Parallelepipede[3];
            figures[0] = new Rectangle("Rouge", 6, 3);
            figures[1] = new Rectangle("Noir", 3, 2);
            figures[2] = new Carre("Blanc", 4);

            for (int i = 0; i < 3; i++)
            {
                Parallelepipede figure = figures[i];
                Console.WriteLine("Figure " + i + ":\n");
                Console.WriteLine(figure);

                Console.WriteLine("surface: " + figure.CalculeSurface());
                Console.WriteLine("perimetre: " + figure.CalculePerimetre());
            }
        }
    }
}