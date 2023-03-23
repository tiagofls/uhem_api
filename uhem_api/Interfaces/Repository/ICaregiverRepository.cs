using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repositories
{
    public interface ICaregiverRepository
    {
        Task<List<CaregiverDto>> GetAll(MySqlConnection con);
        Task<CaregiverDto> GetCaregiverById(MySqlConnection con, int id);
        Task<bool> Post(MySqlConnection con, CaregiverDto data);
    }
}
