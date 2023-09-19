using Microsoft.AspNetCore.Mvc;
using Template.Contracts.Requests.Email;
using Template.Contracts.Responses.GenericResponse;
using Template.Domain.IServices;
namespace Template.API.Controllers
{
    [ApiController]
    [Route("Email")]
    public class EmailBasicController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailBasicController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }


        [HttpPost("SendEmailTest")]
        public async Task<GenericResponse> EmailTest(BasicEmailRequest req)
        {
            return await _emailSender.sendEmail(req);
        }

        [HttpPost("RegisterEmail")]
        public async Task<GenericResponse> RegisterEmail(RegisterEmailRequest req)
        {
            return await _emailSender.RegisterEmail(req);
        }

    }
}
