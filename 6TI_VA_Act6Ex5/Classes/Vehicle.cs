using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex5.Classes
{
    internal abstract class Vehicle
    {
        private string _brand;
        private float _fuel;

        public string Brand { get { return _brand; } }
        public float Fuel { get { return _fuel; } set { _fuel = value; } }

        public Vehicle(string brand, float fuel)
        {
            _brand = brand;
            _fuel = fuel;
        }

        public override string ToString()
        {
            return "brand: " + _brand + ", fuel: " + _fuel + "%";
        }
    }
}
