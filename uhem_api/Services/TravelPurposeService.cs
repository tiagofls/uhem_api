using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces;

namespace uhem_api.Services
{
    public class TravelPurposeService : ITravelPurposeService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly ITravelPurposeRepository _travelPurposeRepository;

        public TravelPurposeService(ITravelPurposeRepository travelPurposeRepository) {

            _travelPurposeRepository = travelPurposeRepository;

            builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = ".XfeJX0T8.GLINTT",
                Database = "uhem",
            };

            con = new MySqlConnection(builder.ConnectionString);
        }

        public async Task<List<TravelPurposeDto>> GetAll()
        {
            try
            {

                var res = await _travelPurposeRepository.GetAll(con);

                return res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
