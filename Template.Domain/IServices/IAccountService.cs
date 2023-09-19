﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Contracts.Requests.Account;
using Template.Contracts.Responses.GenericResponse;
using Template.Domain.Entities;

namespace Template.Domain.IServices
{
    public interface IAccountService
    {
        Task<GenericResponse> Register(AccountRegister req);

        Task<Account?> GetById(int accountId);

        Task<AuthResponse> Login(LoginRequest req);

    }
}
