using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class LoginInfoService : ILoginInfoService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly ILoginInfoRepository _loginInfoRepository;
        public LoginInfoService(ILoginInfoRepository loginInfoRepository)
        {
            _loginInfoRepository = loginInfoRepository;
        }

        public async Task<List<LoginInfoDto>> GetAll()
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.GetAll(con);

                return res;
            }
        }

        public async Task<bool> Post(LoginInfoDto data, string flag)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.Post(con, data, flag);

                return res;
            }
        }

        public async Task<bool> VerifyPassword(string sns, string password, string flag)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.VerifyPassword(con, sns, password, flag);

                return res;
            }
        }
    }
}
