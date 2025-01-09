using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes
{
    internal class Bibliotheque
    {
        private readonly List<Livre> _livres;

        public ImmutableList<Livre> Livres
        {
            get
            {
                return _livres.ToImmutableList();
            }
        }

        public Bibliotheque()
        {
            _livres = new List<Livre>();
        }

        /// <summary>
        /// Ajoute un livre donné dans la liste de livre de cette bibliotheque
        /// </summary>
        /// <param name="livre">Le livre à ajouter</param>
        public void Ajoute(Livre livre)
        {
            _livres.Add(livre);
        }

        /// <summary>
        /// Supprime les livres abimés de la bibliothèque
        /// </summary>
        public void SupprimeLivresAbimes()
        {
            _livres.RemoveAll((l) => l.Etat == 0);
        }

        /// <summary>
        /// Donne tous les livres dans la bibliothèque
        /// </summary>
        /// <returns>Les infos sur tous les livres de la bibliothèque</returns>
        public string Inventaire()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Livres.Count; i++)
            {
                Livre livre = _livres[i];
                sb.AppendLine(livre.Description());
            }
            return sb.ToString();
        }
    }
}
