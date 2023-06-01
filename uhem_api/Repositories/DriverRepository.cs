using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        public DriverRepository() : base() { }

        public async Task<DriverDto> GetById(MySqlConnection con, string id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM db_a9a414_uhemapiuhem_driver WHERE id_driver = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                if (res.FieldCount > 0)
                {
                    return DriverMapper.MapToDriverDto(res);
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
