using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex3.Classes
{
    public class Rectangle : Parallelepipede
    {
        private double _longueur;
        private double _largeur;

        public double Longueur
        {
            get { return _longueur; } set { _longueur = value; }
        }
        public double Largeur
        {
            get { return _largeur; } set { _largeur = value; }
        }

        public Rectangle(string couleur, double longueur, double largeur) : base(couleur)
        {
            _longueur = longueur;
            _largeur = largeur;
        }

        public override double CalculePerimetre()
        {
            return 2 * (_largeur + _longueur);
        }

        public override double CalculeSurface()
        {
            return _largeur * _longueur;
        }

        public override string ToString()
        {
            return base.ToString() + ", longueur: " + _longueur + ", largeur: " + _largeur;
        }
    }
}
