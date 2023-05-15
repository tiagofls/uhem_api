using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repositories
{
    public interface IHealthFacilityRepository
    {
        Task<HealthFacilityDto> GetHealthFacilityById(MySqlConnection con, int id);
    }
}
