using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class TravelPurposeRepository : ITravelPurposeRepository
    {

        public TravelPurposeRepository() : base()
        {
        }

        public async Task<List<TravelPurposeDto>> GetAll(MySqlConnection con)
        {
            try
            {

                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_travel_purpose;";

                var res = await command.ExecuteReaderAsync();

                return TravelPurposeMapper.MapManyToTravelPurposeDto(res);

            }
            catch(Exception e) {
                throw new Exception(e.ToString());
            }
        }

    }
}
