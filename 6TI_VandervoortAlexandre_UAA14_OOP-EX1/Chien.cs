namespace _6TI_VandervoortAlexandre_UAA14_OOP_EX1
{
    internal class Chien
    {
        private ushort _age { get; set; }
        private string _race { get; set; }
        private double _taille { get; set; }
        private double _poid { get; set; }
        private string _etat { get; set; }
        private bool _puce { get; set; }

        private bool nourrit = false;
        private bool aBu = false;

        private static Random randomGen = new Random();

        public Chien(string race, double taille, double poid, string etat, bool puce)
        {
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

            return null;
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

            _age++;
            _taille += randomGen.NextDouble();
            _poid += randomGen.NextDouble() * 10;
            nourrit = false;
            aBu = false;
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

        public override string ToString()
        {
            return "{" + "age: " + _age + ", race: " + _race + ", taille: " + _taille + "m, poid: " + _poid + "kg, etat: " + _etat + ", pucé: " + _puce + "}";
        }
    }
}
