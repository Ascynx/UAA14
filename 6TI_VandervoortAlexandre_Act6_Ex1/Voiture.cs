using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act6_Ex1
{
    internal class Voiture : Vehicule
    {
        private string _motorisation;
        private bool _gps;

        public string Motorisation { get { return _motorisation; } set { _motorisation = value; } }
        public bool Gps { get { return _gps; } set { _gps = value; } }

        public Voiture(string modele, string marque, string couleur, decimal prix, string motorisation, bool gps): base (modele, marque, couleur, prix)
        {
            _motorisation = motorisation;
            _gps = gps;
        }

        public override string Affiche()
        {
            return base.Affiche() + ", motorisation: " + _motorisation + ", gps: " + _gps;
        }
    }
}
