using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.IServices;
using Template.Contracts.Responses.GenericResponse;
using Template.Contracts.Requests.Email;
using Template.Domain.IRepositories;
using Template.Domain.Entities;

namespace Template.Application.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly IEmailRegisteredRepository _repo;

        public EmailSenderService(IEmailRegisteredRepository repo)
        {
            _repo = repo;
        }

        public async Task<GenericResponse> RegisterEmail(RegisterEmailRequest request)
        {
            EmailRegistered newEmail = new EmailRegistered()
            {
                AccountId = request.accountId,
                CreationDate = DateTime.UtcNow,
                LastAltered = DateTime.UtcNow,
                SendDate = request.sendDate,
                MsgBody = request.msgBody,
                Title = request.title,
            };

        
            await _repo.Add(newEmail);

            if(newEmail.EmailRegisteredId != null && newEmail.EmailRegisteredId > 0)
            {
                return new GenericResponse(200, "Email successfuly registered.");
            }

            return new GenericResponse(500, "Email could not be registered.");
        }

        public async Task<GenericResponse> sendEmail(BasicEmailRequest request)
        {
            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("founder@memoruonline.com", "Joao Marques");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(request.email, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = request.msgBody;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            //System.Net.HttpStatusCode.Accepted
            if(response.StatusCode!= System.Net.HttpStatusCode.Accepted)
            {
                return new GenericResponse(((int)response.StatusCode),"Error sending email.");
            }

            return new GenericResponse(((int)response.StatusCode), "Message was sent");
        }
    }
}
