using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class TransportCompanyRepository : ITransportCompanyRepository
    {
        public TransportCompanyRepository() : base() { }

        public async Task<TransportCompanyDto> GetById(MySqlConnection con, string id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_transport_company WHERE id_company = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                if (res.FieldCount > 0)
                {
                    return TransportCompanyMapper.MapToTransportCompanyDto(res);
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
