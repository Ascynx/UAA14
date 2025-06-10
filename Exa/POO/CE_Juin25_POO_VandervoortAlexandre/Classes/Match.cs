using PoolEscrime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    internal class Match
    {
        private int _id;
        
        private Tireur? _tireur1;     //null dans le cas d'une erreur de chargement
        private Tireur? _tireur2;     //null dans le cas d'une erreur de chargement

        private Arbitre? _arbitre;    //null dans le cas d'une erreur de chargement

        private int _touchesTireur1;
        private int _touchesTireur2;

        private string _status;
        public Tireur? Tireur1
        {
            get { return _tireur1; }
        }

        public Tireur? Tireur2
        {
            get { return _tireur2; }
        }

        public Arbitre? Arbitre
        {
            get { return _arbitre; }
        }

        public int Touches1
        {
            get { return _touchesTireur1; }
            set { _touchesTireur1 = value; }
        }
        public int Touches2
        {
            get { return _touchesTireur2; }
            set { _touchesTireur2 = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Match(int id, int tireurId, int tireurId2, int arbitreId, int touches, int touches2, string statut, Pool pool)
        {
            _id = id;
            _tireur1 = pool.GetTireur(tireurId);
            _tireur2 = pool.GetTireur(tireurId2);
            _arbitre = pool.GetArbitre(arbitreId);
            _touchesTireur1 = touches;
            _touchesTireur2 = touches2;
            _status = statut;
        }

        public Match(int id, Tireur tireur1, Tireur tireur2, Arbitre arbitre, int touches1, int touches2, string status)
        {
            _id = id;
            _tireur1 = tireur1;
            _tireur2 = tireur2;
            _arbitre = arbitre;
            _touchesTireur1 = touches1;
            _touchesTireur2 = touches2;
            _status = status;
        }

        public string AfficheInfos()
        {
            string tireur1Info = _tireur1?.AfficheInfos() ?? "Erreur";
            string tireur2Info = _tireur2?.AfficheInfos() ?? "Erreur";
            string arbitreInfo = _arbitre?.AfficheInfos() ?? "Erreur";
            return $"Match: {{\n\tid: {_id};\n\ttireur1: {tireur1Info};\n\ttireur2: {tireur2Info};\n\tarbitre: {arbitreInfo};\n\ttouchesTireur1: {_touchesTireur1};\n\ttouchesTireur2: {_touchesTireur2};\n\tstatus: {_status};\n}}";
        }
    }
}
