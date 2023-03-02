using uhem_api.Dto;

namespace uhem_api.Interfaces.Service
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAll();
    }
}
