using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;

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

        [HttpGet]
        [Route("id")]
        public async Task<TravelPurposeDto> GetById(int id)
        {
            var res = await _travelPurposeService.GetById(id);
            return res;
        }

        [HttpGet]
        [Route("name/id")]
        public async Task<string> GetNameById(int id)
        {
            var res = await _travelPurposeService.GetNameById(id);
            return res;
        }

        [HttpPost]
        public async Task<bool> Post(TravelPurposeDto data)
        {
            var res = await _travelPurposeService.Post(data);
            return res;
        }

        //[HttpDelete]
        //public async Task<bool> Delete(int id)
        //{
        //    var res = await _travelPurposeService.Delete(id);
        //    return res;
        //}

    }
}