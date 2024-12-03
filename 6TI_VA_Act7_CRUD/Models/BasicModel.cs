using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace _6TI_VA_Act7_CRUD.Models
{
    internal class BasicModel
    {
        protected string GetConnString(string database)
        {
            return GetBaseConnString("10.10.51.98", database, 3306, "alexandre", "root");
        }

        protected static string GetBaseConnString(string server, string database, int port, string user, string password)
        {
            return $"server={server};database={database};port={port};User Id={user};password={password}";
        }

        protected bool WriteData(MySQLCommandAdapter adapter, string database)
        {
            bool worked = false;
            WithConnection((conn) =>
            {
                try
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    int affected = adapter.Invoke(cmd).ExecuteNonQuery();
                    worked = affected >= 1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }, database);
            return worked;
        }

        protected bool ReadData(BasicQueryProvider provider, DataAdapterConsumer consumer, string database)
        {
            bool worked = false;
            WithConnection((conn) =>
            {
                try
                {
                    MySqlDataAdapter da = new(provider.Invoke(), conn);
                    worked = consumer.Invoke(da);
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
            }, database);
            return worked;
        }

        protected void WithConnection(ConnectionConsumer consumer, string database)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = GetConnString(database);

            try
            {
                conn.Open();
                consumer.Invoke(conn);
                conn.Close();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        public static Boolean IsDataSetFilled(DataSet set)
        {
            bool filled = false;
            for (int i = 0; i < set.Tables.Count; i++)
            {
                DataTable table = set.Tables[i];
                if (table.Rows.Count >= 1)
                {
                    filled = true;
                    break;
                }
            }
            return filled;
        }

        public delegate void ConnectionConsumer(MySqlConnection conn);

        public delegate bool DataAdapterConsumer(MySqlDataAdapter adapter);

        public delegate string BasicQueryProvider();

        public delegate MySqlCommand MySQLCommandAdapter(MySqlCommand cmd);
    }
}
