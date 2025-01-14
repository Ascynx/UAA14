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
        private Utilisateur _empreinteur;
        private ushort _etatLivre; //avant l'empreint.

        public Livre LivreEmpreinte
        {
            get { return _livreEmpreinte; }
        }

        public DateTime DateEmpreint { get { return _dateEmpreint; } }
        public Utilisateur Empreinteur { get { return _empreinteur; } }
        public ushort etatLivre { get { return _etatLivre; } }

        public Empreint(Livre livre, DateTime date, Utilisateur empreinteur)
        {
            _livreEmpreinte = livre;
            _dateEmpreint = date;
            _empreinteur = empreinteur;
            _etatLivre = livre.Etat;
        }

        public override string ToString()
        {
            return $"Livre: {_livreEmpreinte.Description()}, Date d'empreint: {_dateEmpreint:dd/MM/yyyy}, Empreinteur: {_empreinteur}, Etat du livre avant empreint: {_etatLivre}";
        }
    }
}
