namespace StarWars.Data.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext context,string rootPath);
    }
}
