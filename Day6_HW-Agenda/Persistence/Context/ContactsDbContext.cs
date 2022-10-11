using Day6_HW_Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Day6_HW_Agenda.Persistence.Context
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }
        
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {}
    }
}
