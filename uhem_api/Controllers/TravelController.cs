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

        [HttpGet]
        [Route("appointments")]
        public async Task<List<AppointmentDto>> GetNextAppFromSns(string sns)
        {
            return await _travelService.GetNextAppFromSns(sns);
        }

        [HttpGet]
        [Route("previous-appointment")]
        public async Task<List<AppointmentDto>> GetPreviousAppFromSns(string sns)
        {
            return await _travelService.GetPreviousAppFromSns(sns);
        }

        [HttpGet]
        [Route("set-travel-call")]
        public async Task<bool> SetTravelCall(string id)
        {
            return await _travelService.SetTravelCall(id);
        }
    }
}