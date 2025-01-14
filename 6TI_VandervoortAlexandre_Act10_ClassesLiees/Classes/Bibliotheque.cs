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
        private readonly List<Empreint> _empreints;

        public ImmutableList<Livre> Livres
        {
            get
            {
                return _livres.ToImmutableList();
            }
        }

        public ImmutableList<Empreint> Empreints
        {
            get { return _empreints.ToImmutableList(); }
        }

        public Bibliotheque()
        {
            _livres = new List<Livre>();
            _empreints = new List<Empreint>();
        }

        /// <summary>
        /// Ajoute un livre donné dans la liste de livre de cette bibliotheque
        /// </summary>
        /// <param name="livre">Le livre à ajouter</param>
        public void AjouteLivre(Livre livre)
        {
            _livres.Add(livre);
        }

        /// <summary>
        /// Retire un livre donné de la bibliotheque
        /// </summary>
        /// <param name="livre">Le livre à retirer</param>
        public void RetireLivre(Livre livre)
        {
            _livres.Remove(livre);
        }

        /// <summary>
        /// Supprime les livres abimés de la bibliothèque
        /// </summary>
        public void SupprimeLivresAbimes()
        {
            _livres.RemoveAll((l) => l.Etat == 0);
        }

        /// <summary>
        /// Donne tous les livres dans la bibliothèque ainsi que tous les empreints actuels
        /// </summary>
        /// <returns>Les infos sur tous les livres et tous les empreints de la bibliothèque</returns>
        public string Inventaire()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Livres: ");
            for (int i = 0; i < Livres.Count; i++)
            {
                Livre livre = Livres[i];
                sb.AppendLine(livre.Description());
            }

            sb.AppendLine("\nEmpreints: ");
            for (int i = 0; i < Empreints.Count; i++)
            {
                Empreint empreint = Empreints[i];
                sb.AppendLine(empreint.ToString());
            }

            return sb.ToString();
        }

        public void AjouteEmpreint(Empreint empreint)
        {
            if (_livres.Contains(empreint.LivreEmpreinte))
            {
                empreint.LivreEmpreinte.Empreinte = true;
            }
            _empreints.Add(empreint);
        }

        public void RetireEmpreint(Empreint empreint)
        {
            if (_livres.Contains(empreint.LivreEmpreinte))
            {
                empreint.LivreEmpreinte.Empreinte = false;
                //si l'état du livre est trop différent de l'état avant empreint, fait des trucs, je ne sais pas.
            }
            _empreints.Remove(empreint);
        }
    }
}
