using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    internal class Tireur : Humain
    {
        private Performances _performances; //Performances.

        public Performances Performances
        {
            get { return _performances; }
            set { _performances = value; }
        }

        public Tireur(int id, string? nom, string? prenom) : base(id, nom, prenom)
        {
            _performances = new Performances();
        }

        public override string AfficheInfos()
        {
            return $"Tireur: {{id: {base.Id}; nom: {base.Nom}; prénom: {base.Prenom}; performance: {_performances};}}";
        }
    }
}
