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
    public class ContactRepository : IContactRepository
    {
        private readonly EmailManagementDbContext context;

        public ContactRepository(EmailManagementDbContext _context)
        {
            context = _context;
        }

        public async Task<Contact> Add(Contact entity)
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

        public async Task<List<Contact>> GetAll()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetById(int id)
        {
            return await context.Contacts.Where(x => x.ContactId == id).FirstOrDefaultAsync();
        }
    }
}
