using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle
{
    internal class Cercle
    {
        private double _rayon;

        public double Rayon
        {
            get { return _rayon; }
            set { _rayon = value; }
        }

        public Cercle(double rayon)
        {
            _rayon = rayon;
        }

        public double CalculeAire()
        {
            return Math.PI * Math.Pow(_rayon, 2);
        }

        public double CalculePerimetre()
        {
            return Math.PI * (2 * _rayon);
        }
    }
}
