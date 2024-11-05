namespace _6TI_VA_Act6Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[5];
            animals[0] = new Lapin("Lapin", DateTime.Now, 0, 24, false, 1000);
            animals[1] = new Chat("Chat1", DateTime.Now, 1, 10, false);
            animals[2] = new Chat("Chat2", DateTime.Now, 2, 20, true);
            animals[3] = new Chien("Chien1", DateTime.Now, 3, 30, false);
            animals[4] = new Chien("Chien2", DateTime.Now, 4, 40, true);

            for (int i = 0; i < 5; i++)
            {
                Animal animal = animals[i];
                if (animal is Chat chat)
                {
                    Console.WriteLine(chat.Miaule());
                }
                else if (animal is Chien chien)
                {
                    Console.WriteLine(chien.Aboie());
                }
                else if (animal is Lapin lapin)
                {
                    Console.WriteLine(lapin.Saute());
                }
            }
        }
    }
}