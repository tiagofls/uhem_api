using Microsoft.AspNetCore.Mvc;
using uhem_api.Dto;
using uhem_api.Interfaces.Service;

namespace uhem_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginInfoController : ControllerBase
    {
        private readonly ILoginInfoService _loginInfoService;
        public LoginInfoController(ILoginInfoService loginInfoService)
        {
            _loginInfoService = loginInfoService;
        }

        [HttpGet]
        public async Task<List<LoginInfoDto>> GetAll()
        {
            return await _loginInfoService.GetAll();
        }

        [HttpPost]
        public async Task<bool> Post(LoginInfoDto data)
        {
            return await _loginInfoService.Post(data);
        }

        [HttpGet]
        [Route("verify_pwd")]
        public async Task<bool> VerifyPassword(string username, string password)
        {
            return await _loginInfoService.VerifyPassword(username, password);
        }
    }
}
