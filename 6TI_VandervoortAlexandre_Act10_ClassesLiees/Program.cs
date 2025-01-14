using _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de fonctionnement");
            if (UnitTests.Test(true))
            {
                Console.Clear();
            }

            Console.WriteLine("Bienvenue dans la bibliothèque virtuelle");

            Bibliotheque bibli = new();
            PopulateBibli(bibli);
            while (true)
            {
                int option = Questionneur.QuestionneUtilisateurIntMinMax("Que voulez vous faire?\n 0/ Ajouter un livre\n 1/ Empreinter un livre\n 2/ Rendre un livre\n 3/ Voir l'inventaire\n 4/ Nettoyage complet", 0, 4);

                switch (option)
                {
                    case 0:
                        {
                            string nom = Questionneur.QuestionneUtilisateurSimple("Quel est le nom du livre?");
                            string auteur = Questionneur.QuestionneUtilisateurSimple("Quel est le nom de l'auteur");
                            int etat = Questionneur.QuestionneUtilisateurIntMinMax("Dans une échelle de 0 à 5, 0 étant détruit et 5 en parfaite condition, quel est l'état de ce livre?", 0, 5);
                            Livre livre = new(nom, auteur, (short) etat);
                            bibli.AjouteLivre(livre);
                            Console.WriteLine("Ajouté livre: " + livre.Description());
                            break;
                        }
                    case 1:
                        {
                            string empreinteur = Questionneur.QuestionneUtilisateurSimple("Quel est le nom de la personne qui veut empreinter?");
                            string email = Questionneur.QuestionneUtilisateurSimple("Quelle est l'email de cette personne?");
                            string nom = Questionneur.QuestionneUtilisateurSimple("Quel livre voulez vous empreinter?");
                            Livre livre = bibli.Livres.First((livre) => livre.Titre == nom && !livre.Empreinte);
                            if (livre == null)
                            {
                                Console.WriteLine("Je n'ai pas trouvé livre '" + nom + "' dans la collection");
                                break;
                            }
                            Empreint empreint = new(livre, DateTime.Now, new(empreinteur, email));

                            bibli.AjouteEmpreint(empreint);
                            Console.WriteLine("Empreinté livre: " + livre.Description() + " par: " + empreinteur);
                            break;
                        }
                    case 2: 
                        {
                            string empreinteur = Questionneur.QuestionneUtilisateurSimple("Quel est l'identifiant de l'empreinteur");
                            string nom = Questionneur.QuestionneUtilisateurSimple("Quel livre voulez voulez vous rendre?");
                            Empreint empreint = bibli.Empreints.First((empreint) => empreint.LivreEmpreinte.Titre == nom && empreint.Empreinteur.Identifiant == empreinteur);
                            if (empreint == null)
                            {
                                Console.WriteLine("L'empreint n'a pas été trouvé.");
                                break;
                            }

                            bibli.RetireEmpreint(empreint);
                            Console.WriteLine("Rendu livre '" + empreint.LivreEmpreinte.Titre + "'");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(bibli.Inventaire());
                            break;
                        }
                    case 4:
                        {
                            bibli.SupprimeLivresAbimes();
                            Console.WriteLine(bibli.Inventaire());
                            Console.WriteLine("Retiré les livres dont l'état était détruit (0)");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (!Questionneur.QuestionneUtilisateurYNQuestion("Voulez vous continuer?"))
                {
                    break;
                }
            }
        }

        private static void PopulateBibli(Bibliotheque bibli)
        {
            bibli.AjouteLivre(new Livre("Le temps c'est de l'argent", "Crypto Guru", 4));
            bibli.AjouteLivre(new Livre("C++ pour les nuls", "Pour les nuls", 5));
            bibli.AjouteLivre(new Livre("C qui ça?", "Nan mais vraiment", 1));
            Livre necronomicon = new Livre("Necronomicon", "H.P Lovecraft", 2);

            bibli.AjouteLivre(necronomicon);
            bibli.AjouteEmpreint(new Empreint(necronomicon, DateTime.Now.AddYears(-2000), new Utilisateur("Ḉ̴̯̲͓͈̩̮͛͊t̸̟̻͇̑͐̈́͛͘͝ḧ̵͕́̂̀̌́̽̓͆͊̎͘ü̶̜̭̉́̑́́̇̓͘͝l̴̠̥̜͍̹̟̦̥͉̉̈͋̓͐̈̎̓̓̎͌͝ͅu̴̢͍̪̝̤̯̜͗̀̐̍̑̋͒̆̅̀͜͝", "Indéfini")));
        }
    }
}
