using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class CaregiverRepository : ICaregiverRepository
    {
        public CaregiverRepository() : base() { }

        public async Task<List<CaregiverDto>> GetAll(MySqlConnection con)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_caregiver;";

                var res = await command.ExecuteReaderAsync();

                return CaregiverMapper.MapManyToCaregiverDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<CaregiverDto> GetCaregiverById(MySqlConnection con, int id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_caregiver WHERE id_caregiver = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                return CaregiverMapper.MapToCaregiverDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Post(MySqlConnection con, CaregiverDto data)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_caregiver` (`name`, `email`, `phone`, `address`, `zipcode`) " +
                    "VALUES (@nome, @email, @tel, @add, @zip);";
                command.Parameters.AddWithValue("@nome", data.Name);
                command.Parameters.AddWithValue("@email", data.Email);
                command.Parameters.AddWithValue("@tel", data.Phone);
                command.Parameters.AddWithValue("@add", data.Address);
                command.Parameters.AddWithValue("@zip", data.Zipcode);

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
