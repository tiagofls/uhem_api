using MySqlConnector;

namespace uhem_api
{
    public class SQLConnection
    {
        public SQLConnection() { }
        
        public static MySqlConnection Connect()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection con = new MySqlConnection();

            builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "" /*".XfeJX0T8.GLINTT"*/,
                Database = "uhem",
            };

            return con = new MySqlConnection(builder.ConnectionString);
        }
    }
}
