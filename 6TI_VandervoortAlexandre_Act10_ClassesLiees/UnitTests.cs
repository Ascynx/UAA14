using _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees
{
    internal class UnitTests
    {
        public static Bibliotheque InitBibliotheque()
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            bibliotheque.Ajoute(new Livre("AA", "A1", 5));
            bibliotheque.Ajoute(new Livre("AB", "A2", 4));
            bibliotheque.Ajoute(new Livre("AC", "A1", 3));
            bibliotheque.Ajoute(new Livre("AD", "A3", 2));
            bibliotheque.Ajoute(new Livre("AE", "A4", 1));
            bibliotheque.Ajoute(new Livre("AF", "A5", 0));

            return bibliotheque;
        }

        public static bool Test(bool inConsole)
        {
            Bibliotheque bibliotheque = InitBibliotheque();

            bool etat = TesteBibliotheque(bibliotheque, out StringBuilder stringEtat);
            if (inConsole) Console.WriteLine(stringEtat);

            return etat;
        }

        public static bool TesteDegradationLivre(Livre livre)
        {
            ushort etat = livre.Etat;
            livre.Degrade();
            return (etat == 0 && livre.Etat == 0) || (etat > 0 && livre.Etat == etat - 1);
        }

        public static bool TesteBibliotheque(Bibliotheque bibliotheque, out StringBuilder sb)
        {
            sb = new StringBuilder();
            bool ok = true;
            int livresAbimes = 0;
            for (int i = 0; i < bibliotheque.Livres.Count; i++)
            {
                Livre livre = bibliotheque.Livres[i];
                if (!TesteDegradationLivre(livre))
                {
                    sb.AppendLine(livre.Description() + " (Pas Ok)");

                    ok = false;
                }
                else
                {
                    sb.AppendLine(livre.Description());
                }

                if (livre.Etat == 0)
                {
                    livresAbimes++;
                }
            }

            bibliotheque.SupprimeLivresAbimes();
            if (bibliotheque.Livres.Any((l) => l.Etat == 0))
            {
                sb.AppendLine("Suppression de livres abimés (Pas OK)");
                ok = false;
            }

            sb.AppendLine(bibliotheque.Inventaire());

            return ok;
        }
    }
}
