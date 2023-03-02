using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
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

        public async Task<TravelPurposeDto> GetById(MySqlConnection con, int id)
        {
            try
            {

                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_travel_purpose WHERE id_travel_purpose = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                return TravelPurposeMapper.MapToTravelPurposeDto(res);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Post(MySqlConnection con, TravelPurposeDto data)
        {
            try
            {
                string desc = data.DescriptionTravelPurpose;

                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO UHEM.UHEM_TRAVEL_PURPOSE (description_travel_purpose) VALUES (@desc);";
                command.Parameters.AddWithValue("@desc", desc);

                var res = await command.ExecuteReaderAsync();

                return res != null ? true : false; 

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

    }
}
