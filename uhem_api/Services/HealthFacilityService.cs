using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class HealthFacilityService : IHealthFacilityService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly IHealthFacilityRepository _healthFacilityRepository;
        public HealthFacilityService(IHealthFacilityRepository healthFacilityRepository)
        {
            _healthFacilityRepository = healthFacilityRepository;
        }

        public async Task<HealthFacilityDto> GetHealthFacilityById(int id)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _healthFacilityRepository.GetHealthFacilityById(con, id);
                return res;
            }
        }
    }
}
