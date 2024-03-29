﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("set-sns")]
        public async Task<bool> AssocSns(string username, string sns)
        {
            return await _loginInfoService.AssocSns(username, sns);
        }

        [HttpPost]
        public async Task<bool> Post(LoginInfoDto data, string flag)
        {
            return await _loginInfoService.Post(data, flag);
        }

        [HttpGet]
        [Route("login-assoc")]
        public async Task<string> GetSnsAssoc(string username)
        {
            return await _loginInfoService.GetSnsAssoc(username);
        }

        [HttpGet]
        [Route("verify_pwd")]
        public async Task<bool> VerifyPassword(string sns, string password, string flag)
        {
            return await _loginInfoService.VerifyPassword(sns, password, flag);
        }

        [HttpGet]
        [Route("verify-token-cuidador")]
        public async Task<bool> VerifyTokenCuidador(string username, string token, string password)
        {
            return await _loginInfoService.VerifyTokenCuidador(username, token, password);
        }

        [HttpGet]
        [Route("token")]
        public async Task<string> GenerateToken(string sns, string username)
        {
            return await _loginInfoService.GenerateToken(sns, username);
        }

        [HttpGet]
        [Route("token-cuidador")]
        public async Task<string> TokenCuidador(string email)
        {
            return await _loginInfoService.TokenCuidador(email); 
        }

        [HttpGet]
        [Route("verify_gen_ac")]
        public async Task<bool> VerifyGenAccessCode(string token, string username)
        {
            return await _loginInfoService.VerifyGenAccessCode(token, username);
        }
    }
}
