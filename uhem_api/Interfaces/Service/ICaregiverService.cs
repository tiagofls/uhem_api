using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface ICaregiverService
    {
        Task<List<CaregiverDto>> GetAll();
        Task<CaregiverDto> GetCaregiverById(int id);
        Task<bool> Post(CaregiverDto data);
    }
}