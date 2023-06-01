using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repository
{
    public interface ITransportCompanyRepository
    {
        Task<TransportCompanyDto> GetById(MySqlConnection con, string id);
    }
}
