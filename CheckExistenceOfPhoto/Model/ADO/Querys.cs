namespace CheckExistenceOfPhoto.Model.ADO
{
    public class Querys
    {
        public const string ConnectionString = "Data Source={0}{1}; Version=3;";
        public const string Db = "\\checkImage.sqlite";
        public const string CreateTable = "CREATE TABLE IF NOT EXISTS Imagens (Id INTEGER PRIMARY KEY, Url TEXT, Status BIT)";
        public const string GetAllImagens = "SELECT Id, Url, Status FROM Imagens ORDER BY Id DESC";
        public const string InsertImagens = "INSERT INTO Imagens(Url,Status)VALUES(@Url,@Status)";
    }
}