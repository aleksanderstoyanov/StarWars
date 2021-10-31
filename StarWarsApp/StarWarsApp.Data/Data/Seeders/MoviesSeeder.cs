
namespace StarWarsApp.Data.Data.Seeders
{
    using Newtonsoft.Json;
    using StarWarsApp.Data.Data.Dto;
    using StarWarsApp.Data.Data.Entities;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class MoviesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, string rootPath)
        {
            if (context.Movies.Any())
            {
                return;
            }
            var jsonResult = File.ReadAllText(rootPath);
            var models = JsonConvert.DeserializeObject<MovieDto[]>(jsonResult)
                .Select(movie => new Movie
                {
                    Title=movie.Title,
                    Description=movie.Description,
                    Director=movie.Director,
                    EpisodeId=movie.EpisodeId,
                    Image=movie.Image,
                    Producer=movie.Producer,
                    ReleaseDate=movie.ReleaseDate
                });
            context.Movies.AddRange(models);
            await context.SaveChangesAsync();
        }
    }
}
