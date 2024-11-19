using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal class Plane : Vehicle
    {
        private double _range;

        public double Range
        {
            get { return _range; }
        }
        public Plane(string brand, float fuel, double range) : base(brand, fuel)
        {
            _range = range;
        }

        public override string ToString()
        {
            return base.ToString() + ", range: " + _range;
        }
    }
}
