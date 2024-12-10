using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _6TI_VA_Act7_CRUD.Models
{
    internal class ImageModel : BasicModel
    {
        public static string ImageToString(DataRow row)
        {
            StringBuilder builder = new();

            builder.AppendLine("id: " + row["id"]);
            builder.AppendLine("name: " + row["name"]);
            builder.AppendLine("image: " + row["image"]);
            builder.AppendLine("bienId: " + row["FK_bienId"]);

            return builder.ToString();
        }
        public DataSet GetAllImages(out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => "SELECT * FROM images;", (da) =>
            {
                da.Fill(set, "*");
                return IsDataSetFilled(set);
            });
            return set;
        }

        public bool InsererImage(string nom, string image, int bienId)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "INSERT INTO images(name, image, FK_bienId) VALUES (@name, @image, @bienId);";

                command.Parameters.AddWithValue("name", nom);
                command.Parameters.AddWithValue("image", image);
                command.Parameters.AddWithValue("bienId", bienId);

                return command;
            });
        }

        public bool UpdateImage(int imageId, string column, Object value)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = $"UPDATE images SET {column}=@{column} WHERE id=@imageId;";

                command.Parameters.AddWithValue("imageId", imageId);
                command.Parameters.AddWithValue(column, value);

                return command;
            });
        }

        public bool DeleteImageByBien(int bienId)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "DELETE FROM images WHERE FK_bienId=@bienId;";

                command.Parameters.AddWithValue("bienId", bienId);  

                return command;
            });
        }

        public bool DeleteImage(int imageId)
        {
            return this.WriteData((command) =>
            {
                command.CommandText = "DELETE FROM images WHERE id=@imageId;";

                command.Parameters.AddWithValue("imageId", imageId);

                return command;
            });
        }

        public DataSet ReadImage(int imageId, out bool success)
        {
            DataSet set = new();
            success = this.ReadData(() => $"SELECT * FROM images WHERE id={imageId}", (adapter) =>
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
