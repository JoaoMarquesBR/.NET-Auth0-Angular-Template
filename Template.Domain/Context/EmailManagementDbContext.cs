using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Context
{
    public partial class EmailManagementDbContext : DbContext
    {
        public EmailManagementDbContext()
        {
        }

        public EmailManagementDbContext(DbContextOptions<EmailManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<EmailRegistered> EmailsRegistered { get; set; }
    
    }
}
