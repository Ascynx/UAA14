using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Ingredient
    {
        private string _type;
        private float _quotient;

        public string Type { get => _type; }
        public float Quotient { get => _quotient; set => _quotient = value; }

        public Ingredient(string type, float quotient)
        {
            _type = type;
            _quotient = quotient;
        }

        public override string ToString()
        {
            return $"Type: {_type}, Quotient: {_quotient}";
        }
    }
}
