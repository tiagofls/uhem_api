using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;
using uhem_api.Services;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportCompanyController : ControllerBase
    {
        private readonly ITransportCompanyService _driverService;
        public TransportCompanyController(ITransportCompanyService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<TransportCompanyDto> GetById(int id)
        {
            return await _driverService.GetById(id.ToString());
        }
    }
}
