using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ILoginInfoRepository
    {
        Task<List<LoginInfoDto>> GetAll(MySqlConnection con);
        Task<bool> Post(MySqlConnection con, LoginInfoDto data, string flag);
        Task<bool> VerifyPassword(MySqlConnection con, string sns, string password, string flag);
    }
}
