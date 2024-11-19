using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex4.Classes
{
    internal class Cadre : Employe
    {
        private int _indice;

        public int Indice { get { return _indice; } set { _indice = value; } }
        public double Salaire
        {
            get
            {
                //13000
                //15000 + 2k
                //17000 + 2k
                //20000 + 3k
                int valeur = 13000 + ((_indice - 1) * 2000);
                if (_indice == 4)
                {
                    valeur += 1000;
                }
                return Math.Max(valeur, 20000);
            }
        }


        public Cadre(string matricule, string nom, string prenom, DateTime dateNaissance, int indice) : base(matricule, nom, prenom, dateNaissance)
        {
            _indice = indice;
        }

        public override string ToString()
        {
            return base.ToString() + ", indice: " + _indice + ", salaire: " + Salaire;
        }
    }
}
