using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal class Boat : Vehicle
    {
        private double _tonnage;
        
        public double Tonnage { get { return _tonnage;  } }
        public Boat(string brand, float fuel, double tonnage) : base(brand, fuel)
        {
            _tonnage = tonnage;
        }

        public override string ToString()
        {
            return base.ToString() + ", tonnage: " + _tonnage;
        }
    }
}
