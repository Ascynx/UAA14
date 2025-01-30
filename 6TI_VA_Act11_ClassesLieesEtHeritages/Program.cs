using _6TI_VA_Act11_ClassesLieesEtHeritages.Classes;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salle salleMath = new("m1", 24);
            Salle salleInfo = new("i1", 18);
            Salle salleReseau = new("reseau", 10);

            Departement math = new("Math");
            math.Cours.Add(new Cours("Algebre", salleMath));
            math.Cours.Add(new Cours("Geometrie", salleMath));

            math.Enseignants.Add(
                new("NomProfMath1", "PrenomProfMath1", "xxxxxxxxxx", "@site.asty-moulin.be",  DateTime.Now, math)
                );

            Departement info = new("Informatique");
            info.Cours.Add(new("POO", salleInfo));
            info.Cours.Add(new("Réseau", salleReseau));

            info.Enseignants.Add(
                new("NomProfInfo1", "PrenomProfInfo1", "xxxxxxxxxx", "@site.asty-moulin.be", DateTime.Now, info)
                );


            Ecole ecole = new Ecole("https://www.asty-moulin.be/", "ITN");
            ecole.Etudiants.AddRange(new List<Etudiant>() {
                new("Vandervoort", "Alexandre", "0491xxxxxx", "220857@site.asty-moulin.be", 2022),
                new("xxxxx", "Adrien", "xxxxxxxxxx", "xxxxxx@site.asty-moulin.be", 2021),
                new("xxxxxxx", "Nicolas", "xxxxxxxxxx", "23xxxx@site.asty-moulin.be", 2023)
            });

            ecole.Departements.AddRange(new List<Departement>()
            {
                math, info
            });

            for (int i = 0; i < ecole.Etudiants.Count; i++)
            {
                Etudiant etudiant = ecole.Etudiants[i];
                etudiant.Notes.Add(new(Random.Shared.Next(0, 20), math.Cours.Concat(info.Cours).ToArray()[Random.Shared.Next(0, 3)]));
            }
        }
    }
}
