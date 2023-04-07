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

        public async Task<bool> Post(LoginInfoDto data)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.Post(con, data);

                return res;
            }
        }

        public async Task<bool> VerifyPassword(string username, string password)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.VerifyPassword(con, username, password);

                return res;
            }
        }
    }
}
