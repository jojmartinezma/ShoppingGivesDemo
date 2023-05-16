using Microsoft.EntityFrameworkCore;

namespace testApiInterview1.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contactcs> Contact { get; set; }
    }
}
