using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ILoginInfoService
    {
        Task<List<LoginInfoDto>> GetAll();
        Task<bool> Post(LoginInfoDto data, string flag);
        Task<bool> VerifyPassword(string sns, string password, string flag);
    }
}
