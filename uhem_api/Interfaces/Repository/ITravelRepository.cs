using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ITravelRepository
    {
        Task<List<TravelDto>> GetNextFromSns(MySqlConnection con, string sns);
    }
}