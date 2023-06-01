using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class TransportCompanyService : ITransportCompanyService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly ITransportCompanyRepository _transportCompanyRepository;
        public TransportCompanyService(ITransportCompanyRepository transportCompanyRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task<TransportCompanyDto> GetById(string id)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                return await _transportCompanyRepository.GetById(con, id);
            }
        }
    }
}
