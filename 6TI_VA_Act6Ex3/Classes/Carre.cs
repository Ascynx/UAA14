using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex3.Classes
{
    public class Carre : Parallelepipede
    {
        private double _cote;

        public double Cote
        {
            get { return _cote; } set { _cote = value; }
        }

        public Carre(string couleur, double cote) : base(couleur)
        {
            _cote = cote;
        }

        public override double CalculePerimetre()
        {
            return _cote * 4;
        }

        public override double CalculeSurface()
        {
            return _cote * _cote;
        }

        public override string ToString()
        {
            return base.ToString() + ", cote: " + _cote;
        }
    }
}
