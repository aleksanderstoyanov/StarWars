namespace StarWars.Data.Seeders
{
    using System.Threading.Tasks;
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext context,string rootPath);
    }
}
