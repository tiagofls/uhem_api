using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ILoginInfoService
    {
        Task<List<LoginInfoDto>> GetAll();
        Task<bool> Post(LoginInfoDto data);
        Task<bool> VerifyPassword(string username, string password);
    }
}
