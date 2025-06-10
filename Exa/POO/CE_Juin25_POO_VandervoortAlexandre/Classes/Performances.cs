using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    internal class Performances
    {
        private int _touchesDonnees;
        private int _touchesRecues;
        private int _nbVictoires;

        public int TouchesDonnees
        {
            get { return _touchesDonnees; }
            set { _touchesDonnees = value; }
        }
        public int TouchesRecues
        {
            get { return _touchesRecues; }
            set { _touchesRecues = value; }
        }
        public int NbVictoires
        {
            get { return _nbVictoires; }
            set { _nbVictoires = value; }
        }

        public override string ToString()
        {
            return $"Performances: {{Touches données: {_touchesDonnees}; Touches reçues: {_touchesRecues}; Nombre de victoires: {_nbVictoires};}}";
        }
    }
}
