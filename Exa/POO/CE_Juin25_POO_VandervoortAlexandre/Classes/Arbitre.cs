using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    internal class Arbitre : Humain
    {
        public Arbitre(int id, string? nom, string? prenom) : base(id, nom, prenom) {}

        public override string AfficheInfos()
        {
            return $"Tireur: {{id: {base.Id}; nom: {base.Nom}; prénom: {base.Prenom};}}";
        }
    }
}
