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
    public class EmailRegisteredRepository : IEmailRegisteredRepository
    {
        private readonly EmailManagementDbContext context;

        public EmailRegisteredRepository(EmailManagementDbContext _context)
        {
            context = _context;
        }

        public async Task<EmailRegistered> Add(EmailRegistered entity)
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

        public async Task<List<EmailRegistered>> GetAll()
        {
            return await context.EmailsRegistered.ToListAsync();
        }

        public async Task<EmailRegistered?> GetById(int id)
        {
            return await context.EmailsRegistered.Where(x => x.EmailRegisteredId == id).FirstOrDefaultAsync();
        }
    }
}
