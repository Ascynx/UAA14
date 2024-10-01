using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes
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

        public override string ToString()
        {
            //multiplie et divise les nombres par 100 pour garder 2 décimal de précision tout en retirant le reste.
            return "Le cercle avec un rayon " + (Math.Round(_rayon * 100) / 100) + " a un périmètre de " + (Math.Round(CalculePerimetre() * 100) / 100) + " et une aire de " + (Math.Round(CalculeAire() * 100) / 100);
        }
    }
}
