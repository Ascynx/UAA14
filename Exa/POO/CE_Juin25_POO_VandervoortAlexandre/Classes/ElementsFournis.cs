using CE_Juin25_POO_VandervoortAlexandre.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolEscrime
{
    internal class ElementsFournis
    {
        public static string DefinirCheminBD() 
        {
            // (personellement testé sur le serveur de la classe. db alexandre sur port 3306)
            return "server=localhost;database=poolescrime;port=3308;User Id=root;password=root";
        }
        public static bool ExtraitInfosSelonRequete(Func<MySqlConnection, MySqlCommand> query, out DataSet infos)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            try
            {
                maConnection.Open();

                MySqlDataAdapter da = new(query.Invoke(maConnection)); //crée une nouvelle requête via une instance de MySqlCommand (plus sécurisé que de concaténer des chaînes de caractères)
                infos = new DataSet();
                da.Fill(infos);

                if (infos.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }
                maConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

        public static bool RunDatalessQuery(Func<MySqlConnection, MySqlCommand> query)
        {
            bool ok = false;
            MySqlConnection conn = new MySqlConnection(DefinirCheminBD());
            try
            {
                conn.Open();

                ok = query.Invoke(conn).ExecuteNonQuery() > 0;
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

        /**
         CREATE TABLE Statut (
            statutId INT PRIMARY KEY AUTO_INCREMENT,
            statutInfo VARCHAR(10) NOT NULL //'En Attente', 'En cours', 'Terminé', 'Interrompu'
        );
         */

        public enum StatutMatch
        {
            EnAttente,
            EnCours,
            Terminé,
            Interrompu
        }

        public static StatutMatch FromStatutId(int id)
        {

            StatutMatch v;
            switch (id)
            {
                case 1: v = StatutMatch.EnAttente; break;
                case 2: v = StatutMatch.EnCours; break;
                case 3: v = StatutMatch.Terminé; break;
                case 4: v = StatutMatch.Interrompu; break;
                default: throw new ArgumentOutOfRangeException(nameof(id), "Statut inconnu pour l'Id : " + id);
            };

            return v;
        }

        public static string GetStatutMatch(int statutId)
        {
            return GetStatutMatch(FromStatutId(statutId));
        }   

        public static string GetStatutMatch(StatutMatch statut)
        {
            return statut switch
            {
                StatutMatch.EnAttente => "En Attente",
                StatutMatch.EnCours => "En cours",
                StatutMatch.Terminé => "Terminé",
                StatutMatch.Interrompu => "Interrompu",
                _ => throw new ArgumentOutOfRangeException(nameof(statut), statut, null)
            };
        }

        public static Pool? GetPool(int poolId)
        {
            if (poolId > 3)
            {
                //dans cet exercice, on ne gère pas les pools au-delà de 3.
                return null;
            }
            List<Tireur> tireurs = GetTireursDepuisPool(poolId);
            List<Arbitre> arbitres = GetArbitresDepuisPool(poolId);
            Pool pool = new(poolId, tireurs, arbitres);
            List<Match> matchs = GetInfosMatchsDepuisPool(poolId, pool);
            pool.SetMatchs(matchs);
            return pool;
        }


        public static List<Tireur> GetTireursDepuisPool(int poolId) // "SELECT * FROM Escrimeur where escrimeurId in (SELECT escrimeurId FROM participationPool WHERE poolId= ...);"
        {
            List<Tireur> tireurs = new();

            ExtraitInfosSelonRequete((conn) => {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Escrimeur WHERE escrimeurId in (SELECT escrimeurId FROM participationPool WHERE poolId=@poolId);";
                cmd.Parameters.AddWithValue("@poolId", poolId);
                return cmd;
            }, out DataSet set);

            DataTable table = set.Tables[0];
            if (table == null || table.Rows.Count == 0)
            {
                return tireurs;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                if ((string)row["escrimeurStatut"] != "Tireur")
                {
                    continue;
                }
                int id = (int)row["escrimeurId"];
                string? nom = row["escrimeurNom"].ToString();
                string? prenom = row["escrimeurPrenom"].ToString();
                Tireur tireur = new(id, nom, prenom);
                tireurs.Add(tireur);
            }

            return tireurs;
        }

        public static List<Arbitre> GetArbitresDepuisPool(int poolId) // "SELECT * FROM Escrimeur WHERE escrimeurId in (SELECT DISTINCT arbitreId FROM Matchs WHERE poolId= ...);"
        {
            List<Arbitre> arbitres = new();
            ExtraitInfosSelonRequete((conn) =>
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Escrimeur WHERE escrimeurId in (SELECT DISTINCT arbitreId FROM Matchs WHERE poolId=@poolId);";
                cmd.Parameters.AddWithValue("@poolId", poolId);
                return cmd;
            }, out DataSet set);

            DataTable table = set.Tables[0];
            if (table == null || table.Rows.Count == 0)
            {
                return arbitres;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                if ((string)row["escrimeurStatut"] != "Arbitre")
                {
                    continue;
                }
                int id = (int)row["escrimeurId"];
                string? nom = row["escrimeurNom"].ToString();
                string? prenom = row["escrimeurPrenom"].ToString();
                Arbitre arbitre = new(id, nom, prenom);
                arbitres.Add(arbitre);
            }
            return arbitres;
        }

        public static List<Match> GetInfosMatchsDepuisPool(int poolId, Pool pool) // "SELECT Matchs.matchId, matchTouchesTireur1, matchTouchesTireur2, arbitreId, StatutId, tireurId1, tireurId2 FROM participationmatch INNER JOIN Matchs ON participationmatch.matchId = Matchs.matchId WHERE poolId= ...;"
        {
            List<Match> matchs = new();
            ExtraitInfosSelonRequete((conn) =>
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Matchs.matchId, matchTouchesTireur1, matchTouchesTireur2, arbitreId, StatutId, tireurId1, tireurId2 FROM participationMatch INNER JOIN Matchs ON participationMatch.matchId = Matchs.matchId WHERE poolId=@poolId;";
                cmd.Parameters.AddWithValue("@poolId", poolId);
                return cmd;
            }, out DataSet set);
            DataTable table = set.Tables[0];
            if (table == null || table.Rows.Count == 0)
            {
                return matchs;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                int matchId = (int)row["matchId"];
                int touchesTireur1 = (int)row["matchTouchesTireur1"];
                int touchesTireur2 = (int)row["matchTouchesTireur2"];
                int arbitreId = (int)row["arbitreId"];
                int tireurId1 = (int)row["tireurId1"];
                int tireurId2 = (int)row["tireurId2"];
                int statutId = (int)row["StatutId"];

                string statut = GetStatutMatch(statutId);

                Match match = new Match(matchId, tireurId1, tireurId2, arbitreId, touchesTireur1, touchesTireur2, statut, pool);
                matchs.Add(match);
            }
            return matchs;
        }

        public static Humain? GetEscrimeur(int escrimeurId) // "SELECT * FROM Escrimeur WHERE escrimeurId= ...;"
        {
            Humain? escrimeur = null;
            ExtraitInfosSelonRequete((conn) =>
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Escrimeur WHERE escrimeurId=@escrimeurId;";
                cmd.Parameters.AddWithValue("@escrimeurId", escrimeurId);
                return cmd;
            }, out DataSet set);
            DataTable table = set.Tables[0];
            if (table == null || table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            switch ((string)row["escrimeurStatut"])
            {
                case "Tireur":
                    escrimeur = new Tireur((int)row["escrimeurId"], row["escrimeurNom"].ToString(), row["escrimeurPrenom"].ToString());
                    break;
                case "Arbitre":
                    escrimeur = new Arbitre((int)row["escrimeurId"], row["escrimeurNom"].ToString(), row["escrimeurPrenom"].ToString());
                    break;
                default:
                    throw new Exception("Statut inconnu pour l'escrimeur.");
            }

            return escrimeur;
        }

        public static void InsertPerformances(int poolId, List<Tireur> tireurs)
        {
            RunDatalessQuery((conn) =>
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO performance (perfTouchesDonnees, perfTouchesRecues, perfNbVictoires, poolId, escrimeurId) VALUES ";
                for (int i = 0; i < tireurs.Count; i++)
                {
                    Tireur tireur = tireurs[i];
                    if (i != 0)
                    {
                        cmd.CommandText += ",";
                    }
                    cmd.CommandText += $"(@tD{i}, @tR{i}, @v{i}, {poolId}, {tireur.Id})";

                    cmd.Parameters.AddWithValue($"@tD{i}", tireur.Performances.TouchesDonnees);
                    cmd.Parameters.AddWithValue($"@tR{i}", tireur.Performances.TouchesRecues);
                    cmd.Parameters.AddWithValue($"@v{i}", tireur.Performances.NbVictoires);
                }
                cmd.CommandText += ";";

                return cmd;
            });
        }

        public static void InsertPerformance(int touchesDonnees, int touchesRecues, int victoires, int poolId, int escrimeurId)
        {
            RunDatalessQuery((conn) =>
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO performance (perfTouchesDonnes, perfTouchesRecues, perfNbVictoires, poolId, escrimeurId) VALUES (@touchesDonnees, @touchesRecues, @victoires, @poolId, @escrimeurId);";
                cmd.Parameters.AddWithValue("@touchesDonnes", touchesDonnees);
                cmd.Parameters.AddWithValue("@touchesRecues", touchesRecues);
                cmd.Parameters.AddWithValue("@victoires", victoires);
                cmd.Parameters.AddWithValue("@poolId", poolId);
                cmd.Parameters.AddWithValue("@escrimeurId", escrimeurId);

                return cmd;
            });
        }

        public static StatutMatch GetStatutFromId(int id) // "SELECT statutInfo FROM Statut WHERE statutId= ...;"
        {
            //c'est l'équivalent d'un enum, autant le garder en cache.
            StatutMatch statut = FromStatutId(id);
            return statut;
        }

        /**
         * CREATE TABLE Escrimeur (
                escrimeurId INT PRIMARY KEY AUTO_INCREMENT,
                escrimeurNom VARCHAR(40),
                escrimeurPrenom VARCHAR(20),
                escrimeurLicence VARCHAR(8),
                escrimeurStatut VARCHAR(10), // 'Tireur', 'Arbitre'
                escrimeurLogin VARCHAR(20),
                escrimeurMP VARCHAR(20),
                escrimeurAcces VARCHAR(5) // 'user', 'admin'
        );*/

        /**
        * CREATE TABLE Pool (
            poolId INT PRIMARY KEY AUTO_INCREMENT,
            poolDate DATE,
            poolArme VARCHAR(7),
            poolAdresse VARCHAR(100),
            poolCp VARCHAR(4),
            poolVille VARCHAR(50),
            poolNbTireurs INT
        );
        */

        /**
         CREATE TABLE Matchs (
            matchId INT PRIMARY KEY AUTO_INCREMENT,
            matchTouchesTireur1 INT,
            matchTouchesTireur2 INT,
            poolId INT,
            arbitreId INT,
            statutId INT,
            FOREIGN KEY (poolId) REFERENCES Pool(poolId),
            FOREIGN KEY (arbitreId) REFERENCES Escrimeur(escrimeurId),
            FOREIGN KEY (statutId) REFERENCES Statut(statutId)
        );
        */

        /**
         CREATE TABLE participationMatch (
            participationId INT PRIMARY KEY AUTO_INCREMENT,
            tireurId1 INT,
            tireurId2 INT,
            matchId INT,
            FOREIGN KEY (tireurId1) REFERENCES Escrimeur(escrimeurId),
            FOREIGN KEY (tireurId2) REFERENCES Escrimeur(escrimeurId),
            FOREIGN KEY (matchId) REFERENCES Matchs(matchId)
         );
         */

        /**
         CREATE TABLE participationPool (
            participationPoolId INT PRIMARY KEY AUTO_INCREMENT,
            poolId INT,
            escrimeurId INT,
            FOREIGN KEY (poolId) REFERENCES Pool(poolId),
            FOREIGN KEY (escrimeurId) REFERENCES Escrimeur(escrimeurId)
        );
        */

        /**
        CREATE TABLE Performance (
            perfId INT PRIMARY KEY AUTO_INCREMENT,
            perfTouchesDonnees INT,
            perfTouchesRecues INT,
            perfNbVictoires INT,
            poolId INT,
            escrimeurId INT,
            FOREIGN KEY (poolId) REFERENCES Pool(poolId),
            FOREIGN KEY (escrimeurId) REFERENCES Escrimeur(escrimeurId)
        ); 
        */

        // pour rappel, exemple usage dataset : (int)dataSetInfos.Tables[0].Rows[iEnregistrement]["escrimeurId"]
        // ou encore infoStatut.Tables[0].Rows[0]["statutInfo"].ToString()

        // bon travail...
    }
}
