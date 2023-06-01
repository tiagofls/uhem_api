using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface IDriverRepository
    {
        Task<DriverDto> GetById(MySqlConnection con, string id);
    }
}
