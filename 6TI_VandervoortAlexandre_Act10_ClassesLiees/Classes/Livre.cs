using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes
{
    internal class Livre
    {
        private string _titre;
        private string _auteur;
        private ushort _etat; //5 à 0.

        private bool _empreinte;

        public string Titre { get { return _titre; } }
        public string Auteur { get { return _auteur; } }

        public ushort Etat { get { return _etat; } set { _etat = value; } }

        public bool Empreinte { get { return _empreinte; } set { _empreinte = value; } }

        public Livre(string titre, string auteur, short etat)
        {
            _titre = titre;
            _auteur = auteur;
            _etat = (ushort)etat;
        }

        /// <summary>
        /// Change le degré de dégat du livre, max est 5, min est 0.
        /// </summary>
        public void Degrade()
        {
            if (_etat == 0)
            {
                return;
            }
            _etat -= 1;
        }

        /// <summary>
        /// Donne une description de l'état du livre, son nom et son auteur.
        /// </summary>
        /// <returns></returns>
        public string Description()
        {
            return $"Titre: {_titre}, Auteur: {_auteur}, état: {_etat}, empreinté: {(_empreinte == true ? "Oui" : "Non")}";
        }
    }
}
