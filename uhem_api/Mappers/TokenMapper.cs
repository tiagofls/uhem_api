using MySqlConnector;
using uhem_api.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace uhem_api.Mappers
{
    public class TokenMapper
    {
        public static List<TokenDto> MapManyToTokenDto(MySqlDataReader data)
        {
            List<TokenDto> l = new List<TokenDto>();

            while (data.Read())
            {
                TokenDto t = new TokenDto
                {
                    Username = data.GetString("username"),
                    Status = data.GetString("status"),
                    Token = data.GetString("token"),
                    Date = data.GetDateTime("dt_cri")
                };

                l.Add(t);
            }

            return l;
        }

        public static TokenDto MapToTokenDto(MySqlDataReader data)
        {
            TokenDto t = new TokenDto();

            if (data.Read())
            {
                t.Username = data.GetString("username");
                t.Status = data.GetString("status");
                t.Token = data.GetString("token");
                t.Date = data.GetDateTime("dt_cri");
            }

            return t;
        }
    }
}
