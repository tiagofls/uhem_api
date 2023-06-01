using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IHealthFacilityService
    {
        Task<HealthFacilityDto> GetHealthFacilityById(int id);
        Task<string> GetHealthFacilityNameById(int id);
    }
}
