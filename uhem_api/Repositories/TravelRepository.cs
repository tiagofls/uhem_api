using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        public TravelRepository() : base()
        {
        }
        public async Task<List<TravelDto>> GetNextFromSns(MySqlConnection con, string sns)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_travel WHERE date_travel >= CURRENT_TIMESTAMP AND id_patient IN (SELECT id_patient FROM uhem_patient WHERE sns = @sns) ORDER BY date_travel ASC;";
                command.Parameters.AddWithValue("@sns", sns);

                var res = await command.ExecuteReaderAsync();


                return TravelMapper.MapManyToTravelDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
