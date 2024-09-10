namespace _6TI_VandervoortAlexandre_UAA14_OOP_EX1
{
    internal class Chien
    {
        private string _nom;
        private ushort _age;
        private string _race;
        private double _taille;
        private double _poid;
        private string _etat;
        private bool _puce;

        private bool nourrit = false;
        private bool aBu = false;

        private static Random randomGen = new Random();

        public Chien(string nom, string race, double taille, double poid, string etat, bool puce)
        {
            _nom = nom;
            _age = 0;
            _race = race;
            _taille = taille;
            _poid = poid;
            _etat = etat;
            _puce = puce;
        }

        public string Manger()
        {
            if (nourrit == false)
            {
                nourrit = true;
            } 

            if (_etat == "Affamé")
            {
                _etat = "Bonne santé";
            }

            return null;
        }

        public void VieillirSkipCheck()
        {
            _age++;
            _taille += randomGen.NextDouble();
            _poid += randomGen.NextDouble() * 10;
            nourrit = false;
            aBu = false;
        }

        public void Vieillir()
        {
            if (!nourrit || !aBu)
            {
                if (_etat == "Affamé")
                {
                    Mourrir();
                } else
                {
                    _etat = "Affamé";
                }
                return;
            }

            if (_age > 17)
            {
                Mourrir();
                return;
            }

            VieillirSkipCheck();
        }

        public string Boire()
        {
            if (aBu == false)
            {
                aBu = true;
            }
            return null;
        }

        public void Blesser()
        {
            if (_etat != "Mort" && _etat != "Blessé")
            {
                _etat = "Blessé";
            }
        }

        public void Mourrir()
        {
            if (_etat != "Mort")
            {
                _etat = "Mort";
                _race = "Os";
            }
        }

        public ushort GetAge()
        {
            return _age;
        }

        public string GetRace() { return _race; }

        public string GetEtat()
        {
            return _etat;
        }

        public string AfficheCaracteristiques()
        {
            return "Nom : " + _nom + " Age : " + _age + " Race : " + _race;
        }

        public override string ToString()
        {
            return _nom + ": {" + "age: " + _age + ", race: " + _race + ", taille: " + (Math.Round(_taille * 100) / 100) + "m, poid: " + (Math.Round(_poid * 100) / 100) + "kg, etat: " + _etat + ", pucé: " + _puce + "}";
        }
    }
}
