using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Contracts.Requests.Email;
using Template.Contracts.Responses.GenericResponse;

namespace Template.Domain.IServices
{
    public interface IEmailSender
    {
        Task<GenericResponse> sendEmail(BasicEmailRequest request);


        Task<GenericResponse> RegisterEmail(RegisterEmailRequest request);

    }
}
