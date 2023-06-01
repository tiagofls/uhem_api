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
                Server = "MYSQL6008.site4now.net",
                UserID = "a9a414_uhemapi",
                Password = "Tiagosantos1",
                Database = "db_a9a414_uhemapi",
            };


            return con = new MySqlConnection(builder.ConnectionString);
        }
    }
}
