using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    internal abstract class Humain
    {
        private int _id;
        private string _nom; // "Inconnu" si il y a eu une erreur de chargement pour cet Id;
        private string _prenom; // "Inconnu" si il y a eu une erreur de chargement pour cet Id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
        }

        public string Prenom
        {
            get { return _prenom; }
        }

        public Humain(int id, string? nom, string? prenom)
        {
            _id = id;
            if (nom != null)
                _nom = nom;
            else
                _nom = "Inconnu";
            if (prenom != null)
                _prenom = prenom;
            else
                _prenom = "Inconnu";
        }

        public abstract string AfficheInfos();
    }
}
