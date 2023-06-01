using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class DriverService : IDriverService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<DriverDto> GetById(string id)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                return await _driverRepository.GetById(con, id);
            }
        }
    }
}
