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
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CharacterMovie> CharacterMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterMovie>()
                .HasKey(x => new { x.CharacterId, x.MovieId });
        }
    }
}
