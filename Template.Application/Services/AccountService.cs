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
using Template.Domain.Entities;
using Template.Contracts.Requests.Account;
using Template.Domain.IRepositories;

namespace Template.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public Task<Account?> GetById(int accountId)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> Login(LoginRequest req)
        {
            Account? acc = await _repo.GetByEmail(req.email);

            if (acc == null)
            {
                return new AuthResponse(404, "User not found", null);
            }
            else if (acc.Password.Equals(req.password))
            {
                return new AuthResponse(200, "Correct Password", "NEW_TOKEN_GENERATED");
            }
            else
            {
                return new AuthResponse(200, "Wrong password", null);
            }

        }

        public async Task<GenericResponse> Register(AccountRegister req)
        {
            Account acc = new Account
            {
                FirstName = req.firstName,
                LastName = req.lastName,
                Email = req.email,
                Password = req.password,
                Username = req.username,
            };

            try
            {
                Account? VerifyIfAccountExists = await _repo.GetByEmail(req.email);
                
                if(VerifyIfAccountExists != null)
                    return new GenericResponse(500, "Email is already in use");


                await _repo.Add(acc);

                if (acc.AccountId == null || acc.AccountId <= 0)
                    return new GenericResponse(500, "User could not be added to DB");

                return new GenericResponse(200, "Account was added to DB");
            }
            catch (Exception ex)
            {
                return new GenericResponse(500, ex.Message);
            }
        }

    }
}
