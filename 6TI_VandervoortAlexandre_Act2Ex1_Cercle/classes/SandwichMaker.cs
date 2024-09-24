using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act2Ex1_Cercle.classes
{
    internal class SandwichMaker
    {
        private static readonly Random RANDOM = new();

        private string[] _proteines;
        private string[] _condiments;
        private string[] _pains;
        private string[] _crudites;

        public string[] Proteines { get { return _proteines; } }
        public string[] Condiments { get { return _condiments; } }
        public string[] Pains { get { return _pains; } }
        public string[] Crudites { get { return _crudites; } }

        public SandwichMaker(string[] proteines, string[] condiments, string[] pains, string[] crudites)
        {
            _proteines = proteines;
            _condiments = condiments;
            _pains = pains;
            _crudites = crudites;
        }

        public string ComposeSandwich()
        {
            //pain, proteine, crudite, condiment
            StringBuilder sandwich = new();
            string pain = _pains[RANDOM.Next(_pains.Length)];
            string proteine = _proteines[RANDOM.Next(_proteines.Length)];
            string crudite = _crudites[RANDOM.Next(_crudites.Length)];
            string condiment = _condiments[RANDOM.Next(_condiments.Length)];
            sandwich.Append(pain).Append(", ").Append(proteine).Append(", ").Append(crudite).Append(", ").Append(condiment);

            return sandwich.ToString();
        }
    }
}
