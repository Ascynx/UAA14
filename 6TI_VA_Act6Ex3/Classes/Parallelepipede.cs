using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex3.Classes
{
    public abstract class Parallelepipede
    {
        protected string _couleur;

        public string Couleur
        {
            get { return _couleur; } set { _couleur = value; }
        }

        public Parallelepipede(string couleur)
        {
            _couleur = couleur;
        }

        public abstract double CalculeSurface();
        public abstract double CalculePerimetre();

        public override string ToString()
        {
            return "couleur: " + _couleur;
        }
    }
}
