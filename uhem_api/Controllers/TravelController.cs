using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {

            _travelService = travelService;

        }

        [HttpGet]
        public async Task<List<TravelV2Dto>> GetNextFromSns(string sns)
        {
            return await _travelService.GetNextFromSns(sns);
        }

        [HttpGet]
        [Route("previous")]
        public async Task<List<TravelV2Dto>> GetPreviousFromSns(string sns)
        {
            return await _travelService.GetPreviousFromSns(sns);
        }
    }
}