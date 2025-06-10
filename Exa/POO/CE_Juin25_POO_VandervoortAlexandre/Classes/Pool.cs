using PoolEscrime;
using System.Text;

namespace CE_Juin25_POO_VandervoortAlexandre.Classes
{
    class Pool
    {
        private int _identifiant;
        
        private List<Tireur> _tireurs;
        private List<Arbitre> _arbitres;

        private List<Match> _matchs;

        public Pool(int identifiant, List<Tireur> tireurs, List<Arbitre> arbitres)
        {
            _identifiant = identifiant;
            _tireurs = tireurs;
            _arbitres = arbitres;
            _matchs = [];
        }

        public void SetMatchs(List<Match> matchs)
        {
            _matchs = matchs;
        }

        public Tireur? GetTireur(int id)
        {
            for (int i = 0; i < _tireurs.Count; i++)
            {
                if (_tireurs[i].Id == id)
                {
                    return _tireurs[i];
                }
            }
            return null;
        }

        public Arbitre? GetArbitre(int id)
        {
            for (int i = 0; i < _arbitres.Count; i++)
            {
                if (_arbitres[i].Id == id)
                {
                    return _arbitres[i];
                }
            }
            return null;
        }

        public int CherchePlaceDansListe(int id)
        {
            for (int i = 0; i < _tireurs.Count; i++)
            {
                if (_tireurs[i].Id == id)
                {
                    return i;
                }
            }
            return -1; // Retourne -1 si l'ID n'est pas trouvé
        }

        public bool Terminee()
        {
            for (int i = 0; i < _matchs.Count; i++)
            {
                if (_matchs[i].Status != "Terminé")
                {
                    return false; // Si au moins un match n'est pas terminé, le pool n'est pas terminé
                }
            }

            return true;
        }

        public void UpdateBDDPerformances()
        {
            ElementsFournis.InsertPerformances(_identifiant, _tireurs);
        }

        public void CalculPerformancesParTireur()
        {
            for (int i = 0; i < _tireurs.Count; i++)
            {
                Tireur tireur = _tireurs[i];
                tireur.Performances = new(); //reset vu que l'on recalcule.
            }
            for (int i = 0; i < _matchs.Count; i++)
            {
                Match match = _matchs[i];
                if (match.Status != "Terminé")
                {
                    continue; // Ignore les matchs non terminés
                }

                if (match.Tireur1 != null)
                {
                    Performances performance = match.Tireur1.Performances;

                    performance.NbVictoires += match.Touches1 > match.Touches2 ? 1 : 0;
                    performance.TouchesDonnees += match.Touches1;
                    performance.TouchesRecues += match.Touches2;
                    match.Tireur1.Performances = performance;
                }
                if (match.Tireur2 != null)
                {
                    Performances performance = match.Tireur2.Performances;

                    performance.NbVictoires += match.Touches2 > match.Touches1 ? 1 : 0;
                    performance.TouchesDonnees += match.Touches2;
                    performance.TouchesRecues += match.Touches1;
                    match.Tireur2.Performances = performance;
                }
            }
        }

        public string AfficherParticipantsPool()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Pool ID: {_identifiant}");
            stringBuilder.AppendLine("=========================================================================");
            stringBuilder.AppendLine("Tireurs:");
            foreach (var tireur in _tireurs)
            {
                stringBuilder.AppendLine(tireur.AfficheInfos()).Append("\n");
            }
            stringBuilder.AppendLine("=========================================================================");
            stringBuilder.AppendLine("Arbitres:");
            foreach (var arbitre in _arbitres)
            {
                stringBuilder.AppendLine(arbitre.AfficheInfos()).Append("\n");
            }
            return stringBuilder.ToString();
        }

        public string AfficherRecapitulatifCompletMatchs()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Recapitulatif des matchs pour le Pool ID: {_identifiant}");
            stringBuilder.AppendLine("=========================================================================");
            foreach (var match in _matchs)
            {
                stringBuilder.AppendLine(match.AfficheInfos()).Append("\n");
            }
            return stringBuilder.ToString();
        }

        public string AfficherPerformanceTireurs()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Performances des tireurs pour le Pool ID: {_identifiant}");
            if (!Terminee())
            {
                stringBuilder.AppendLine("Attention, cette pool n'est pas terminée, les résultats peuvent encore êtres mis à jour");
            }
            stringBuilder.AppendLine("=========================================================================");
            foreach (var tireur in _tireurs)
            {
                stringBuilder.AppendLine(tireur.Nom + " " + tireur.Prenom + " -> " + tireur.Performances).Append("\n");
            }
            return stringBuilder.ToString();
        }
    }
}
