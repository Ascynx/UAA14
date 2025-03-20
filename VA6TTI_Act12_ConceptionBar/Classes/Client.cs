using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA6TTI_Act12_ConceptionBar.Classes
{
    internal class Client
    {
        private int _age;

        public int Age { get => _age; }

        public Client(int age)
        {
            _age = age;
        }
    }
}
