using MySqlConnector;
using Newtonsoft.Json.Linq;
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

        public async Task<bool> AssocSns(string username, string sns)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.AssocSns(con, username, sns);

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

        public async Task<bool> VerifyTokenCuidador(string username, string token, string password)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.VerifyTokenCuidador(con, username, token, password);

                return res;
            }
        }

        public async Task<string> GetSnsAssoc(string username)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.GetSnsAssoc(con, username);

                return res;
            }
        }

        public async Task<string> GenerateToken(string sns, string username)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.GenerateToken(con, sns, username);

                return res;
            }
        }

        public async Task<string> TokenCuidador(string email)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.TokenCuidador(con, email);

                return res;
            }
        }

        public async Task<bool> VerifyGenAccessCode(string token, string username)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _loginInfoRepository.VerifyGenAccessCode(con, token, username);

                return res;
            }
        }
    }
}
