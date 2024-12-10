using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act7_CRUD.Models
{
    internal class BienModel : BasicModel
    {
        public static string BienToString(DataRow row)
        {
            StringBuilder builder = new();

            builder.AppendLine("id: " + row["bienId"]);
            builder.AppendLine("nom: " + row["nom"]);
            builder.AppendLine("taille: " + row["taille"]);
            builder.AppendLine("prix: " + row["prix"]);
            builder.AppendLine("ville: " + row["ville"]);
            builder.AppendLine("userId: " + row["userId"]);
            builder.AppendLine("description: " + row["description"]);
            builder.AppendLine("chambres: " + row["chambres"]);
            builder.AppendLine("image: " + row["imageBien"]);

            return builder.ToString();
        }
        public DataSet GetAllBiens(out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => "SELECT * FROM biens;", (da) =>
            {
                da.Fill(set, "*");
                return IsDataSetFilled(set);
            });
            return set;
        }

        public bool InsererBien(string nom, int taille, int prix, string ville, int userId, string description, int chambre, int image)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "INSERT INTO biens(nom, taille, prix, ville, userId, description, chambres, imageBien) VALUES (@nom, @taille, @prix, @ville, @userId, @description, @chambres, @imageBien);";
                
                command.Parameters.AddWithValue("nom", nom);
                command.Parameters.AddWithValue("taille", taille);
                command.Parameters.AddWithValue("prix", prix);
                command.Parameters.AddWithValue("ville", ville);
                command.Parameters.AddWithValue("userId", userId);
                command.Parameters.AddWithValue("description", description);
                command.Parameters.AddWithValue("chambres", chambre);
                command.Parameters.AddWithValue("image", image);

                return command;
            });
        }

        public bool InsererBien(string nom, int taille, int prix, string ville, int userId, string description, int chambre)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "INSERT INTO biens(nom, taille, prix, ville, userId, description, chambres) VALUES (@nom, @taille, @prix, @ville, @userId, @description, @chambres);";

                command.Parameters.AddWithValue("nom", nom);
                command.Parameters.AddWithValue("taille", taille);
                command.Parameters.AddWithValue("prix", prix);
                command.Parameters.AddWithValue("ville", ville);
                command.Parameters.AddWithValue("userId", userId);
                command.Parameters.AddWithValue("description", description);
                command.Parameters.AddWithValue("chambres", chambre);

                return command;
            });
        }

        public bool UpdateBien(int bienId, string column, Object value)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = $"UPDATE biens SET {column}=@{column} WHERE bienId=@bienId;";

                command.Parameters.AddWithValue("bienId", bienId);
                command.Parameters.AddWithValue(column, value);

                return command;
            });
        }

        public bool DeleteBien(int bienId)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "DELETE FROM biens WHERE bienId=@bienId;";

                command.Parameters.AddWithValue("bienId", bienId);

                return command;
            });
        }

        public DataSet ReadBien(int bienId, out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => $"SELECT * FROM biens WHERE bienId={bienId}", (adapter) =>
            {
                adapter.Fill(set, "*");
                return true;

            });
            return set;
        }

        protected bool ReadData(BasicQueryProvider provider, DataAdapterConsumer consumer)
        {
            return this.ReadData(provider, consumer, GetDefaultDatabase());
        }
        protected bool WriteData(MySQLCommandAdapter adapter)
        {
            return this.WriteData(adapter, GetDefaultDatabase());
        }
    }
}
