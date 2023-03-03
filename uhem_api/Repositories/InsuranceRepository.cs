using MySqlConnector;
using System.Xml.Linq;
using uhem_api.Dto;
using uhem_api.Interfaces.Repository;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        public InsuranceRepository() { }

        public async Task<List<InsuranceDto>> GetAll(MySqlConnection con)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_insurance;";

                var res = await command.ExecuteReaderAsync();

                return InsuranceMapper.MapManyToInsuranceDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<InsuranceDto> GetById(MySqlConnection con, int id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_insurance WHERE id_insurance = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                return InsuranceMapper.MapToInsuranceDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<InsuranceDto> GetByName(MySqlConnection con, string name)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_insurance WHERE name_insurance = @name;";
                command.Parameters.AddWithValue("@name", name);

                var res = await command.ExecuteReaderAsync();

                return InsuranceMapper.MapToInsuranceDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Post(MySqlConnection con, InsuranceDto data)
        {
            try
            {
                string name = data.NameInsurance != null ? data.NameInsurance : "";
                string email = data.EmailInsurance != null ? data.EmailInsurance : "";
                string phone = data.PhoneInsurance!= null ? data.PhoneInsurance : "";

                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_insurance` (`name_insurance`, `email_insurance`, `phone_insurance`) VALUES (@name, @email, @phone);";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);

                var res = await command.ExecuteReaderAsync();

                return res != null ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Delete(MySqlConnection con, int id)
        {
            try
            {
                await con.OpenAsync();
                var command = con.CreateCommand();
                command.CommandText = "DELETE FROM UHEM.UHEM_INSURANCE WHERE id_insurance = @id;";
                command.Parameters.AddWithValue("@id", id);

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
