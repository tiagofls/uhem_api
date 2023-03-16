using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Mappers;

namespace uhem_api.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository() : base() { }

        public async Task<List<PaymentDto>> GetAll(MySqlConnection con)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_payment;";

                var res = await command.ExecuteReaderAsync();

                return PaymentMapper.MapManyToPaymentDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<PaymentDto> GetPaymentById(MySqlConnection con, int id)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "SELECT * FROM uhem.uhem_payment WHERE id_payment = @id;";
                command.Parameters.AddWithValue("@id", id);

                var res = await command.ExecuteReaderAsync();

                return PaymentMapper.MapToPaymentDto(res);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Post(MySqlConnection con, PaymentDto data)
        {
            try
            {
                await con.OpenAsync();

                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO `uhem`.`uhem_payment` (`paid`, `amount`) VALUES (@paid, @amount);";
                command.Parameters.AddWithValue("@paid", data.Paid);
                command.Parameters.AddWithValue("@amount", data.Amount);

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
