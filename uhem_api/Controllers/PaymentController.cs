using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<List<PaymentDto>> GetAll()
        {
            return await _paymentService.GetAll();
        }

        [HttpGet]
        [Route("id")]
        public async Task<PaymentDto> GetPaymentById(int id)
        {
            return await _paymentService.GetPaymentById(id);
        }

        [HttpPost]
        public async Task<bool> Post(PaymentDto data)
        {
            return await _paymentService.Post(data);
        }
    }
}
