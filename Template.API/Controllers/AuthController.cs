using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Public")]
        public async Task<ActionResult<string>> PublicTest()
        {
            var response = new
            {
                Message = "Public OK"
            };

            return Ok(response);
        }

        [HttpPost("AuthTest")]
        [Authorize]
        public async Task<ActionResult<string>> AuthTest()
        {
            var response = new
            {
                Message = "Auth required OK"
            };

            return Ok(response);
        }



    }
}
