using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act6_Ex1
{
    internal class Velo : Vehicule
    {
        private string _type;
        private bool _estElectrique;

        public string Type { get { return _type; } set { _type = value; } }
        public bool EstElectrique { get { return _estElectrique; } set { _estElectrique = value; } }

        public Velo(string modele, string marque, string couleur, decimal prix, string type, bool estElectrique): base (modele, marque, couleur, prix)
        {
            _type = type;
            _estElectrique = estElectrique;
        }

        public override string Affiche()
        {
            return base.Affiche() + ", type: " + _type + ", electrique: " + _estElectrique;
        }
    }
}
