using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Mappers
{
    public class LoginInfoMapper
    {
        public static List<LoginInfoDto> MapManyToLoginInfoDto(MySqlDataReader data)
        {
            List<LoginInfoDto> l = new List<LoginInfoDto>();

            while (data.Read())
            {
                LoginInfoDto t = new LoginInfoDto
                {
                    EncryptedPassword = data.GetString("encrypted_password"),
                    Username = data.GetString("username")
                };

                l.Add(t);
            }

            return l;
        }

        public static LoginInfoDto MapToLoginInfoDto(MySqlDataReader data)
        {
            LoginInfoDto t = new LoginInfoDto();

            if (data.Read())
            {
                t.EncryptedPassword = data.GetString("encrypted_password");
                t.Username = data.GetString("username");
            }

            return t;
        }
    }
}
