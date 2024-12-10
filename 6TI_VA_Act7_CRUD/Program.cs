using _6TI_VA_Act7_CRUD.Classes;
using _6TI_VA_Act7_CRUD.Models;
using System.Data;

namespace _6TI_VA_Act7_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //modifier la database utilisée est dans BasicModel#GetDefaultDatabase.

            BienModel model = new BienModel();
            ImageModel imageModel = new ImageModel();

            Console.WriteLine("Accès BDD biens");
            while (true)
            {
                Console.Clear();
                int choix = Questionneur.QuestionneUtilisateurIntMinMax("Actions possible\n 1: Lister biens\n 2: Modifier bien\n 3: Supprimer bien\n 4: Ajouter bien", 1, 4);
                switch (choix)
                {
                    case 1:
                        {
                            DataSet data = model.GetAllBiens(out bool success);
                            if (!success)
                            {
                                Console.WriteLine("Erreur: pas réussi à query la BDD");
                                break;
                            }
                            DataTable dt = data.Tables[0];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow row = dt.Rows[i];
                                Console.WriteLine(BienModel.BienToString(row));
                            }

                            break;
                        }
                    case 2:
                        {
                            int id = Questionneur.QuestionneUtilisateurInt("Quelle ligne voulez vous modifier (Id)?");
                            string colonne = Questionneur.QuestionneUtilisateurSimple("Quelle colonne?");
                            string value = Questionneur.QuestionneUtilisateurSimple("Quelle valeur?");
                            if (!model.UpdateBien(id, colonne, value))
                            {
                                Console.WriteLine("Erreur: pas réussi à query la BDD");
                            }
                            break;
                        }
                    case 3:
                        {
                            int id = Questionneur.QuestionneUtilisateurInt("Quelle ligne voulez vous supprimer (Id)?");
                            if (!imageModel.DeleteImageByBien(id))
                            {
                                Console.WriteLine("Erreur: pas réussi à query la BDD");
                            }
                            if (!model.DeleteBien(id))
                            {
                                Console.WriteLine("Erreur: pas réussi à query la BDD");
                            }
                            break;
                        }
                    case 4:
                        {
                            string nom = Questionneur.QuestionneUtilisateurSimple("Quel est le nom de ce bien?");
                            int taille = Questionneur.QuestionneUtilisateurInt("Quelle est la taille de ce bien?");
                            int prix = Questionneur.QuestionneUtilisateurInt("Quel est le prix de ce bien?");
                            string ville = Questionneur.QuestionneUtilisateurSimple("Dans quelle ville se trouve ce bien?");
                            int uId = Questionneur.QuestionneUtilisateurInt("Quel est l'id de l'utilisateur qui l'a posté?");
                            string description = Questionneur.QuestionneUtilisateurSimple("Description fournie avec le bien?");
                            int chambre = Questionneur.QuestionneUtilisateurInt("Quelle est la quantité de chambre dans ce bien?");
                            bool aImage = Questionneur.QuestionneUtilisateurYNQuestion("Y-a t'il une image fournie avec?");
                            if (aImage)
                            {
                                int image = Questionneur.QuestionneUtilisateurInt("L'Id d'une image du bien");
                                if (!model.InsererBien(nom, taille, prix, ville, uId, description, chambre, image))
                                {
                                    Console.WriteLine("Erreur: pas réussi à query la BDD");
                                }
                                break;
                            }
                            
                            if (!model.InsererBien(nom, taille, prix, ville, uId, description, chambre))
                            {
                                Console.WriteLine("Erreur: pas réussi à query la BDD");
                            }
                            break;
                        }
                    default: break;
                }

                if (!Questionneur.QuestionneUtilisateurYNQuestion("Voulez vous continuer?"))
                {
                    break;
                }
            }
        }
    }
}