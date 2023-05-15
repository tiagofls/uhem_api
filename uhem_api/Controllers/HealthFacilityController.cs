using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;
using uhem_api.Services;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthFacilityController : ControllerBase
    {
        private readonly IHealthFacilityService _healthFacilityService;
        public HealthFacilityController(IHealthFacilityService healthFacilityService)
        {
            _healthFacilityService = healthFacilityService;
        }

        [HttpGet]
        [Route("id")]
        public async Task<HealthFacilityDto> GetHealthFacilityById(int id)
        {
            return await _healthFacilityService.GetHealthFacilityById(id);
        }

    }
}
