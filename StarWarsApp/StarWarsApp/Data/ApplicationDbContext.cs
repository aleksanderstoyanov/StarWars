namespace StarWars.Data
{
    using Microsoft.EntityFrameworkCore;
    using StarWars.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
