using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Context;
using Template.Domain.Entities;
using Template.Domain.IRepositories;

namespace Template.Infrastructure.Persistence
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmailManagementDbContext context;

        public AccountRepository(EmailManagementDbContext _context)
        {
            context = _context;
        }

        public async Task<Account> Add(Account entity)
        {
            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<List<Account>> GetAll()
        {
            return await context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByEmail(string email)
        {
            return await context.Accounts.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<Account?> GetById(int id)
        {
            return await context.Accounts.Where(x => x.AccountId == id).FirstOrDefaultAsync();
        }

    }
}
