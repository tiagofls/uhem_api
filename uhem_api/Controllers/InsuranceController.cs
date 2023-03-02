using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;
        public InsuranceController(IInsuranceService insuranceService) {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<List<InsuranceDto>> GetAll()
        {
            var res = await _insuranceService.GetAll();
            return res;
        }

        [HttpGet]
        [Route("id")]
        public async Task<InsuranceDto> GetById(int id)
        {
            var res = await _insuranceService.GetById(id);
            return res;
        }

        [HttpGet]
        [Route("name")]
        public async Task<InsuranceDto> GetByName(string name)
        {
            var res = await _insuranceService.GetByName(name);
            return res;
        }

        [HttpPost]
        public async Task<bool> Post(InsuranceDto data)
        {
            var res = await _insuranceService.Post(data);
            return res;
        }
    }
}
