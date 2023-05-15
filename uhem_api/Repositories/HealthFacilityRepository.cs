using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class HealthFacilityRepository : IHealthFacilityRepository
    {
        public HealthFacilityRepository() : base() { }

        public async Task<HealthFacilityDto> GetHealthFacilityById(MySqlConnection con, int id)
        {
            try
            {
                if(con.State.ToString().CompareTo("Closed") == 0) await con.OpenAsync(); 

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_health_facility WHERE id_facility = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                return HealthFacilityMapper.MapToHealthFacilityDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
