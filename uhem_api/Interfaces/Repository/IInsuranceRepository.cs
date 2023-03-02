using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface IInsuranceRepository
    {
        Task<List<InsuranceDto>> GetAll(MySqlConnection con);
        Task<InsuranceDto> GetById(MySqlConnection con, int id);
        Task<InsuranceDto> GetByName(MySqlConnection con, string name);
        Task<bool> Post(MySqlConnection con, InsuranceDto data);
        //Task<bool> Delete(MySqlConnection con, int id);
    }
}
