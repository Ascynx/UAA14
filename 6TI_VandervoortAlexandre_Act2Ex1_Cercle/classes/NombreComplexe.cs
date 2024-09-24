using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes
{
    internal class NombreComplexe
    {
        private double _reel;
        private double _imaginaire;

        public double Reel { get { return _reel; } set { _reel = value; } }
        public double Imaginaire { get { return _imaginaire; } set { _imaginaire = value; } }

        NombreComplexe(double reel, double imaginaire)
        {
            _reel = reel;
            _imaginaire = imaginaire;
        }

        string AfficheComplexe()
        {
            return "(" + _reel + ", " + _imaginaire + ")";
        }

        double CalculeModule()
        {
            return Math.Pow(_reel, 2) + Math.Pow(_imaginaire, 2);
        }

        void Ajoute(NombreComplexe nombreComplexe)
        {
            _reel += nombreComplexe.Reel;
            _imaginaire += nombreComplexe.Imaginaire;
        }
    }
}
