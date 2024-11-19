using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal class Truck : RoadVehicle
    {
        private double _weight;

        public double Weight
        {
            get
            {
                return _weight;
            }
        }

        public Truck(string brand, float fuel, double km, double weight) : base(brand, fuel, km)
        {
            _weight = weight;
        }

        public override string ToString()
        {
            return base.ToString() + ", weight: " + _weight;
        }
    }
}
