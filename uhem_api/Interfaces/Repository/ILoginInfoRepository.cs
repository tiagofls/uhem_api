using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ILoginInfoRepository
    {
        Task<List<LoginInfoDto>> GetAll(MySqlConnection con);
        Task<bool> Post(MySqlConnection con, LoginInfoDto data, string flag);
        Task<bool> VerifyPassword(MySqlConnection con, string sns, string password, string flag);
        Task<string> GenerateToken(MySqlConnection con, string sns, string username);
        Task<string> TokenCuidador(MySqlConnection con, string email);
        Task<bool> VerifyGenAccessCode(MySqlConnection con, string token, string username);
        Task<bool> VerifyTokenCuidador(MySqlConnection con, string username, string token, string password);
        Task<string> GetSnsAssoc(MySqlConnection con, string username);
        Task<bool> AssocSns(MySqlConnection con, string username, string sns);
    }
}
