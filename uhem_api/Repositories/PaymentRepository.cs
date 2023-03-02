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

    }
}
