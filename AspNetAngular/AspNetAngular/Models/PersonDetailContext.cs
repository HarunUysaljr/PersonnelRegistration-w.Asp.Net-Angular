using Microsoft.EntityFrameworkCore;

namespace AspNetAngular.Models
{
    public class PersonDetailContext : DbContext
    {
        public PersonDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonDetails> PersonDetails { get; set; }
    }
}
