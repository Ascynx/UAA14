using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act6Ex2
{
    public abstract class Animal
    {
        protected string _nom;
        protected DateTime _dateNaissance;
        protected int _numPuce;
        protected decimal _taille;
        protected bool _estConcurrent;

        protected Animal(string nom, DateTime dateNaissance, int numPuce, decimal taille, bool estConcurrent)
        {
            _nom = nom;
            _dateNaissance = dateNaissance;
            _numPuce = numPuce;
            _taille = taille;
            _estConcurrent = estConcurrent;
        }

        public string Nom { get { return _nom; } set { _nom = value; } }
        public DateTime DateNaissance { get { return _dateNaissance; } }
        public int NumPuce { get { return _numPuce; } }
        public decimal Taille { get { return _taille; } set { _taille = value; } }
        public bool EstConcurrent { get { return _estConcurrent; } set { _estConcurrent = value; } }

        public void Dormir()
        {

        }
        public void Manger(string nourriture)
        {

        }
    }
}
