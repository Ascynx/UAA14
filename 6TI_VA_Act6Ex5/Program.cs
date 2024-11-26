using System.Reflection.Emit;
using _6TI_VA_Act6Ex5.Classes;

namespace _6TI_VA_Act6Ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Bienvenue dans le programme concessionnaire.");

            bool continuer = true;
            while (continuer) {
                int choix = Questionneur.QuestionneUtilisateurIntMinMax("Quel type de véhicule voulez vous?\n1) Bateau\n2) Voiture\n3) Avion\n4) Camion.", 1, 4);
                Vehicle? vehicule = ChoiceToVehicle(choix);
                if (vehicule == null) {
                    System.Console.WriteLine("Erreur, je n'ai pas compris votre choix.");
                    break;
                }

                if (vehicule is Boat boat) {
                    System.Console.WriteLine(boat);
                } else if (vehicule is Car car) {
                    System.Console.WriteLine(car);
                } else if (vehicule is Plane plane) {
                    System.Console.WriteLine(plane);
                } else if (vehicule is Truck truck) {
                    System.Console.WriteLine(truck);
                }

                continuer = Questionneur.QuestionneUtilisateurYNQuestion("Voulez vous continuer? y: oui, n: non");
            }
        }

        static Vehicle? ChoiceToVehicle(int choix) {
            return choix switch
            {
                1 => new Boat("boat company", 0.0F, 60D),
                2 => new Car("car company", 0.0F, 60000.05D),
                3 => new Plane("plane company", 0.0F, 600D),
                4 => new Truck("truck company", 0.0F, 30000D, 6000D),
                _ => null,
            };
        }
    }
}