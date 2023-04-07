using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class SaltMapper
    {

        public static SaltDto MapToSaltDto(MySqlDataReader data)
        {
            SaltDto t = new SaltDto();

            if (data.Read())
            {
                t.Username = data.GetString("username");
                t.Salt = data.GetString("salt");
            }

            return t;
        }
    }
}
