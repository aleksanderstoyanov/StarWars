namespace StarWarsApp.Services.Services.Movies
{
    using AutoMapper.QueryableExtensions;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Services.Services.Cache;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MovieService : BaseService, IMoviesService
    {
        private readonly ICacheService cacheService;
        private readonly ApplicationDbContext dbContext;
        public MovieService(ICacheService cacheService, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.cacheService = cacheService;
        }
        public async Task DeleteAsync(int id)
        {
            var movie = this.dbContext.Movies
            .FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                movie.isDeleted= true;
            }
            await this.dbContext.SaveChangesAsync();
        }
        public MovieServiceModel GetById(int id)
        {
            var movie = this.dbContext.Movies
                .ProjectTo<MovieServiceModel>(configuration)
                .FirstOrDefault(movie => movie.Id == id);
            return movie;
        }
        public IEnumerable<MovieServiceModel> GetAll()
        {
            var movies = this.cacheService.GetCachedMovies();
            return movies;
        }
    }
}

