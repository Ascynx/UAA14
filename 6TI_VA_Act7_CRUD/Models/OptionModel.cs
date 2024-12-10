using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TI_VA_Act7_CRUD.Models
{
    internal class OptionModel : BasicModel
    {
        public static string OptionsToString(DataRow row)
        {
            StringBuilder builder = new();

            builder.AppendLine("id: " + row["optionId"]);
            builder.AppendLine("nom: " + row["optionNom"]);

            return builder.ToString();
        }
        public DataSet GetAllOptions(out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => "SELECT * FROM options;", (da) =>
            {
                da.Fill(set, "*");
                return IsDataSetFilled(set);
            });
            return set;
        }

        public bool InsererOption(string nom)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "INSERT INTO options(nom) VALUES (@nom);";

                command.Parameters.AddWithValue("nom", nom);

                return command;
            });
        }

        public bool UpdateOption(int optionId, string column, Object value)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = $"UPDATE options SET {column}=@{column} WHERE optionId=@optionId;";

                command.Parameters.AddWithValue("optionId", optionId);
                command.Parameters.AddWithValue(column, value);

                return command;
            });
        }

        public bool DeleteOption(int optionId)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "DELETE FROM options WHERE optionId=@optionId;";

                command.Parameters.AddWithValue("optionId", optionId);

                return command;
            });
        }

        public DataSet ReadOption(int optionId, out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => $"SELECT * FROM options WHERE optionId={optionId}", (adapter) =>
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
