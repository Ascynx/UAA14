using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act7_CRUD.Models
{
    internal class UtilisateurModel : BasicModel
    {
        public static string UtilisateurToString(DataRow row)
        {
            StringBuilder builder = new();

            builder.AppendLine("id: " + row["userId"]);
            builder.AppendLine("nom: " + row["nomUser"]);
            builder.AppendLine("prenom: " + row["prenomUser"]);
            builder.AppendLine("login: " + row["loginUser"]);
            builder.AppendLine("password: " + row["passWordUser"]);
            builder.AppendLine("role: " + row["role"]);

            return builder.ToString();
        }

        public DataSet GetAllUsers(out bool success)
        {
            DataSet set = new();
            success = ReadData(() => "SELECT * FROM utilisateurs", (adapter) =>
            {
                adapter.Fill(set, "*");
                return true;
            });
            return set;
        }

        public bool InsererUtilisateur(string nom, string prenom, string login, string password, string role)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "INSERT INTO utilisateurs (nomUser, prenomUser, loginUser, passWordUser, role) VALUES (@nom, @prenom, @login, @password, @role)";

                command.Parameters.AddWithValue("nom", nom);
                command.Parameters.AddWithValue("prenom", prenom);
                command.Parameters.AddWithValue("login", login);
                command.Parameters.AddWithValue("password", password);
                command.Parameters.AddWithValue("role", role);

                return command;
            });
        }

        public bool UpdateUtilisateur(int userId, string column, Object value)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = $"UPDATE utilisateurs SET {column}=@{column} WHERE userId=@userId";

                command.Parameters.AddWithValue("userId", userId);
                command.Parameters.AddWithValue(column, value);

                return command;
            });
        }

        public bool DeleteUtilisateur(int userId)
        {
            return WriteData((command) =>
            {
                command.CommandText = $"DELETE FROM utilisateurs WHERE userId=@userId";

                command.Parameters.AddWithValue("userId", userId);

                return command;
            });
        }

        public DataSet ReadUtilisateur(int userId, out bool success)
        {
            DataSet set = new();
            success = ReadData(() => $"SELECT * FROM utilisateurs WHERE userId={userId}", (adapter) =>
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
