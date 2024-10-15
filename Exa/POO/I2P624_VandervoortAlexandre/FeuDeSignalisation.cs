using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I2P624_VandervoortAlexandre
{
    internal class FeuDeSignalisation
    {
        private int _couleur;
        private readonly string _identifiant;
        private bool _etat;

        public int Couleur { get { return _couleur; } set { _couleur = value; } }
        public bool Etat { get { return _etat; } set { _etat = value; } }

        public FeuDeSignalisation(int couleur, string identifiant, bool etat)
        {
            _couleur = couleur;
            _identifiant = identifiant;
            _etat = etat;
        }

        public int ChangeCouleur(int couleur)
        {
            _couleur = couleur;
            return _couleur;
        }

        public void ChangeEtat()
        {
            _etat = !_etat;
        }

        public void Clignote(int nbAlternance)
        {
            Console.WriteLine("Le feu de signalisation " + _identifiant + " est " + (Etat ? "allumé" : "éteint") + ".");
            for (int i = 0; i < nbAlternance; i++)
            {
                ChangeEtat();
                Console.WriteLine("Le feu de signalisation " + _identifiant + " est " + (Etat ? "allumé" : "éteint") + ".");
            }
        }

        public string AfficheCouleur()
        {
            return "Le feu de signalisation " + _identifiant + " est " + GetStringColorRepresentation(_couleur);
        }

        public string AfficheEtat()
        {
            return "Le feu de signalisation " + _identifiant + " est " + GetStringColorRepresentation(_couleur) + " et " + (Etat ? "allumé" : "éteint") + ".";
        }

        static string GetStringColorRepresentation(int couleur)
        {
            switch (couleur)
            {
                case 0:
                    {
                        return "Vert";
                    }
                case 1:
                    {
                        return "Orange";
                    }
                case 2:
                    {
                        return "Rouge";
                    }
                default:
                    {
                        return "UNKNOWN";
                    }
            }
        }
    }
}
