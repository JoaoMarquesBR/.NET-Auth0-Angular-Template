using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Template.Contracts.Requests.Account;
using Template.Contracts.Responses.GenericResponse;
using Template.Domain.IServices;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("PublicAuthTest")]
        public async Task<ActionResult<string>> PublicTest()
        {
            var response = new
            {
                Message = "Public OK"
            };

            return Ok(response);
        }

        [HttpPost("PrivateAuthTest")]
        [Authorize]
        public async Task<ActionResult<string>> AuthTest()
        {
            var response = new
            {
                Message = "Auth required OK"
            };

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<GenericResponse> AddAccount(AccountRegister req)
        {
            return await _accountService.Register(req);
        }

        [HttpPost("Login")]
        public async Task<AuthResponse> Login(LoginRequest req)
        {
            return await _accountService.Login(req);
        }


    }
}
