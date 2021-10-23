namespace StarWarsApp.Data.Data
{
    using Microsoft.EntityFrameworkCore;
    using StarWarsApp.Data.Data.Entities;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
