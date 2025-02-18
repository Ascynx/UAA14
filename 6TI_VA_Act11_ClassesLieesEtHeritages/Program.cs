using _6TI_VA_Act11_ClassesLieesEtHeritages.Classes;
using System.Text;

namespace _6TI_VA_Act11_ClassesLieesEtHeritages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salle amphitheatre = new Salle("Amphitheatre A", 200);
            Salle conference = new Salle("Salle de conférence B", 100);
            Salle classe = new Salle("Salle de classe C", 30);

            Departement math = new Departement("Math");
            math.Cours.Add(new Cours("Algebre", amphitheatre));
            math.Cours.Add(new Cours("Geometrie", amphitheatre));

            Departement info = new Departement("Informatique");
            info.Cours.Add(new Cours("POO", classe));
            info.Cours.Add(new Cours("Réseau", conference));

            Departement physique = new Departement("Physique");
            physique.Cours.Add(new Cours("Mécanique", amphitheatre));
            physique.Cours.Add(new Cours("Optique", conference));

            Departement chimie = new Departement("Chimie");
            chimie.Cours.Add(new Cours("Chimie Organique", classe));
            chimie.Cours.Add(new Cours("Chimie Inorganique", conference));

            Departement biologie = new Departement("Biologie");
            biologie.Cours.Add(new Cours("Biologie Cellulaire", classe));
            biologie.Cours.Add(new Cours("Génétique", amphitheatre));

            math.Enseignants.Add(
                 new Enseignant("Dupont", "Jean", "0498xxxxxx", "jean.dupont@site.asty-moulin.be", new DateTime(2020, 9, 1), math)
            );
            info.Enseignants.Add(
                new Enseignant("Martin", "Sophie", "0498xxxxxx", "sophie.martin@site.asty-moulin.be", new DateTime(2018, 9, 1), info)
                );
            physique.Enseignants.Add(
                new Enseignant("Durand", "Pierre", "0498xxxxxx", "pierre.durand@site.asty-moulin.be", new DateTime(2019, 9, 1), physique)
                );
            chimie.Enseignants.Add(
                new Enseignant("Lefevre", "Marie", "0498xxxxxx", "marie.lefevre@site.asty-moulin.be", new DateTime(2021, 9, 1), chimie)
                );
            biologie.Enseignants.Add(
                new Enseignant("Moreau", "Luc", "0498xxxxxx", "luc.moreau@site.asty-moulin.be", new DateTime(2017, 9, 1), biologie)
                );

            Ecole ecole = new Ecole("https://www.asty-moulin.be/", "ITN");

            ecole.Etudiants.AddRange(new List<Etudiant>() {
                new("Bernard", "Marie", "0100000001", "marie.bernard@example.com", 2021),
                new("Durand", "Alexandre", "0100000002", "alexandre.durand@example.com", 2020),
                new("Dubois", "Sophie", "0100000003", "sophie.dubois@example.com", 2019),
                new("Martin", "Lucas", "0100000004", "lucas.martin@example.com", 2022),
                new("Thomas", "Emma", "0100000005", "emma.thomas@example.com", 2023),
                new("Petit", "Hugo", "0100000006", "hugo.petit@example.com", 2018),
                new("Robert", "Chloé", "0100000007", "chloe.robert@example.com", 2019),
                new("Richard", "Maxime", "0100000008", "maxime.richard@example.com", 2020),
                new("Simon", "Léa", "0100000009", "lea.simon@example.com", 2021),
                new("Moreau", "Nathan", "0100000010", "nathan.moreau@example.com", 2022)
            });

            ecole.Departements.AddRange(new List<Departement>()
            {
                math, info, physique, chimie, biologie
            });


            IEnumerable<Cours> toutCours = math.Cours.Concat(info.Cours).Concat(physique.Cours).Concat(chimie.Cours).Concat(biologie.Cours);
            for (int i = 0; i < ecole.Etudiants.Count; i++)
            {
                Etudiant etudiant = ecole.Etudiants[i];
                Cours cours = toutCours.ToArray()[Random.Shared.Next(0, toutCours.Count() - 1)];
                int note = Random.Shared.Next(0, 20);
                etudiant.Notes.Add(new(note, cours));
                cours.Notes.Add(note);
            }

            Console.WriteLine(ecole);
        }

        public static String PrintList<T>(List<T> list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\t[");

            if (list.Count > 0)
            {
                stringBuilder.AppendLine();
            }
            for (int i = 0; i < list.Count; i++)
            {
                T item = list[i];
                stringBuilder.AppendLine("\t\t" + item.ToString() + ",");
            }
            stringBuilder.Append("\t]");

            return stringBuilder.ToString();
        }
    }
}
