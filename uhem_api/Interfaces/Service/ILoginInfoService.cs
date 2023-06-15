using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ILoginInfoService
    {
        Task<List<LoginInfoDto>> GetAll();
        Task<bool> Post(LoginInfoDto data, string flag);
        Task<bool> VerifyPassword(string sns, string password, string flag);
        Task<string> GenerateToken(string sns, string username);
        Task<bool> VerifyGenAccessCode(string token, string username);
        Task<string> TokenCuidador(string email);
        Task<bool> VerifyTokenCuidador(string username, string token, string password);
        Task<string> GetSnsAssoc(string username);
        Task<bool> AssocSns(string username, string sns);
    }
}
