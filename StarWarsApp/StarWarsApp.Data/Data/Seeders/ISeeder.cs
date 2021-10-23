namespace StarWarsApp.Data.Data.Seeders
{
    using StarWarsApp.Data.Data;
    using System.Threading.Tasks;
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext context, string rootPath);
    }
}
