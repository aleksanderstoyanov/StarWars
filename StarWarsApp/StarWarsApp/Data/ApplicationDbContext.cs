namespace StarWars.Data
{
    using Microsoft.EntityFrameworkCore;
    using StarWars.Data.Entities;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
