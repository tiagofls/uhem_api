using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class CaregiverService : ICaregiverService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly ICaregiverRepository _caregiverRepository;
        public CaregiverService(ICaregiverRepository caregiverRepository)
        {
            _caregiverRepository = caregiverRepository;
        }

        public async Task<List<CaregiverDto>> GetAll()
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _caregiverRepository.GetAll(con);
                return res;
            }
        }

        public async Task<CaregiverDto> GetCaregiverById(int id)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _caregiverRepository.GetCaregiverById(con, id);
                return res;
            }
        }

        public async Task<bool> Post(CaregiverDto data)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _caregiverRepository.Post(con, data);
                return res;
            }
        }
    }
}
