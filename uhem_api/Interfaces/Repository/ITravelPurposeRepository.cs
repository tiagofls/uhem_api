using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repositories
{
    public interface ITravelPurposeRepository
    {

        Task<List<TravelPurposeDto>> GetAll(MySqlConnection con);

    }
}
