using MySqlConnector;
using uhem_api.Dto;

namespace uhem_api.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<PaymentDto>> GetAll(MySqlConnection con);
        Task<PaymentDto> GetPaymentById(MySqlConnection con, int id);
        Task<bool> Post(MySqlConnection con, PaymentDto data);
    }
}
