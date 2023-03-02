using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;

namespace uhem_api.Services
{
    public class PaymentService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository) {

            _paymentRepository = paymentRepository;

            builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = ".XfeJX0T8.GLINTT",
                Database = "uhem",
            };

            con = new MySqlConnection(builder.ConnectionString);
        }

        public async Task<List<PaymentDto>> GetAll()
        {
            var res = await _paymentRepository.GetAll(con);
            return res;
        }
    }
}
