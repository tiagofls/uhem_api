using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<PatientDto> GetBySns(MySqlConnection con, string sns);
        Task<PatientDto> GetById(MySqlConnection con, int id);
    }
}
