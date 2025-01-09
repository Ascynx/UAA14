using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VandervoortAlexandre_Act10_ClassesLiees.Classes
{
    internal class Empreint
    {
        private Livre _livreEmpreinte;
        private DateTime _dateEmpreint;
        private string _empreinteur;
        private ushort _etatLivre; //avant l'empreint.

        public Livre LivreEmpreinte
        {
            get { return _livreEmpreinte; }
        }

        public DateTime DateEmpreint { get { return _dateEmpreint; } }
        public string Empreinteur { get { return _empreinteur; } }
        public ushort etatLivre { get { return _etatLivre; } }

        public Empreint(Livre livre, DateTime date, string nomEmpreinteur)
        {
            _livreEmpreinte = livre;
            _dateEmpreint = date;
            _empreinteur = nomEmpreinteur;
            _etatLivre = livre.Etat;
        }

        public override string ToString()
        {
            return $"Livre: {_livreEmpreinte.Description()}, Date d'empreint: {_dateEmpreint:dd/MM/yyyy}, Empreinteur: {_empreinteur}, Etat du livre avant empreint: {_etatLivre}";
        }
    }
}
