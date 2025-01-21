using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I5_6TTIUAA14_Vandervoort.Classes
{
    internal class Joueur
    {
        private string _pseudo;
        private byte _nbCartouchesEnPoche;
        private PaintBallGun _myPaintBallGun;

        public string Pseudo { get { return _pseudo; } }
        public byte NbCartouchesEnPoche { get { return _nbCartouchesEnPoche; } set {  _nbCartouchesEnPoche = value; } }
        public PaintBallGun MyPaintBallGun {  get { return _myPaintBallGun;} set { _myPaintBallGun = value; } }

        public Joueur(string pseudo, PaintBallGun fusil)
        {
            _pseudo = pseudo;
            _nbCartouchesEnPoche = 30;
            _myPaintBallGun = fusil;
        }

        public string Recharger()
        {
            byte ajoutee = (byte)Math.Min(_nbCartouchesEnPoche, _myPaintBallGun.TailleChargeur - _myPaintBallGun.NbBallesChargeur);
            _myPaintBallGun.NbBallesChargeur += ajoutee;
            _nbCartouchesEnPoche -= ajoutee;
            return $"Recharge de {ajoutee} balles dans le chargeur effectuée";
        }

        public bool Tire()
        {
            if (_myPaintBallGun.ChargeurEstVide())
            {
                return false;
            }

            _myPaintBallGun.NbBallesChargeur -= 1;
            return true;
        }

        public string VerifiePoche()
        {
            return $"Vous avez un total de {_nbCartouchesEnPoche} cartouches dans votre poche et {_myPaintBallGun.NbBallesChargeur} balles dans le chargeur";
        }
    }
}
