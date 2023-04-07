using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ILoginInfoRepository
    {
        Task<List<LoginInfoDto>> GetAll(MySqlConnection con);
        Task<bool> Post(MySqlConnection con, LoginInfoDto data);
        Task<bool> VerifyPassword(MySqlConnection con, string username, string password);
    }
}
