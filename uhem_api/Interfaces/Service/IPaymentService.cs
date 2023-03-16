using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAll();
        Task<PaymentDto> GetPaymentById(int id);
        Task<bool> Post(PaymentDto data);
    }
}
