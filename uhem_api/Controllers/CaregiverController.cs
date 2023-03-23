using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;
using uhem_api.Services;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverService _caregiverService;
        public CaregiverController(ICaregiverService caregiverService)
        {
            _caregiverService = caregiverService;
        }

        [HttpGet]
        public async Task<List<CaregiverDto>> GetAll()
        {
            return await _caregiverService.GetAll();
        }

        [HttpGet]
        [Route("id")]
        public async Task<CaregiverDto> GetCaregiverById(int id)
        {
            return await _caregiverService.GetCaregiverById(id);
        }

        [HttpPost]
        public async Task<bool> Post(CaregiverDto data)
        {
            return await _caregiverService.Post(data);
        }
    }
}
