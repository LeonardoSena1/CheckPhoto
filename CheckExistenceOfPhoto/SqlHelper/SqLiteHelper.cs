using CheckExistenceOfPhoto.Model;
using CheckExistenceOfPhoto.Model.ADO;
using System.Data.SQLite;

namespace CheckExistenceOfPhoto.SqlHelper
{
    public class SqLiteHelper
    {
        public static string ConnectionString
        {
            get
            {
                return string.Format(Querys.ConnectionString, Environment.CurrentDirectory, Querys.Db);
            }
        }

        public static void CreateDatabase()
        {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + Querys.Db))
            {
                SQLiteConnection.CreateFile(Environment.CurrentDirectory + Querys.Db);
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(Querys.CreateTable, connection))
                        command.ExecuteNonQuery();
                }
            }
        }

        public static List<ImagensModel> GetAllImagens()
        {
            List<ImagensModel> Imagens = new List<ImagensModel>();

            using (var sqlCnn = new SQLiteConnection(ConnectionString))
            {
                sqlCnn.Open();

                using (var sqlCmd = new SQLiteCommand(Querys.GetAllImagens, sqlCnn))
                using (var sqlReader = sqlCmd.ExecuteReader())
                    while (sqlReader.Read())
                        Imagens.Add(
                            new ImagensModel()
                            {
                                Id = sqlReader["Id"] != DBNull.Value ? (long)sqlReader["Id"] : -1,
                                Url = sqlReader["Url"] != DBNull.Value ? (string)sqlReader["Url"] : string.Empty,
                                Status = sqlReader["Status"] != DBNull.Value ? (bool)sqlReader["Status"] : false
                            });
            }

            return Imagens;
        }

        public static void InsertImage(ImagensModel Model)
        {
            using (var sqlCnn = new SQLiteConnection(ConnectionString))
            {
                sqlCnn.Open();

                using (var sqlCmd = new SQLiteCommand(Querys.InsertImagens, sqlCnn))
                {
                    _ = sqlCmd.Parameters.AddWithValue("@Url", Model.Url);
                    _ = sqlCmd.Parameters.AddWithValue("@Status", Model.Status);
                    _ = sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
