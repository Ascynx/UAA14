using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I5_6TTIUAA14_Vandervoort.Classes
{
    internal class PaintBallGun
    {
        private byte _nbBallesChargeur;
        private readonly byte _tailleChargeur = 16;

        public byte NbBallesChargeur { get { return _nbBallesChargeur; } set { _nbBallesChargeur = value; } }
        public byte TailleChargeur { get { return _tailleChargeur; } }

        public PaintBallGun()
        {
            _nbBallesChargeur = 0;
        }

        public bool ChargeurEstVide()
        {
            return _nbBallesChargeur == 0;
        }
    }
}
