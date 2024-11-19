using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal abstract class RoadVehicle : Vehicle
    {
        private double _km;

        public double Km
        {
            get { return _km; }
            set { _km = value; }
        }
        protected RoadVehicle(string brand, float fuel, double km) : base(brand, fuel)
        {
            _km = km;
        }

        public override string ToString()
        {
            return base.ToString() + ", km: " + _km;
        }
    }
}
