using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelPurposeController : ControllerBase
    {
        private readonly ITravelPurposeService _travelPurposeService;

        public TravelPurposeController(ITravelPurposeService travelPurposeService){
            
           _travelPurposeService = travelPurposeService;
 
        }

        [HttpGet]
        public async Task<List<TravelPurposeDto>> GetAll()
        {
            var res = await _travelPurposeService.GetAll();

            return res;
        }

    }
}