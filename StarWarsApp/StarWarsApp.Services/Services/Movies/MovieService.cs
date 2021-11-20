namespace StarWarsApp.Services.Services.Movies
{
    using AutoMapper.QueryableExtensions;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Services.Services.Cache;
    using System.Collections.Generic;
    using System.Linq;
    public class MovieService :BaseService, IMoviesService
    {
        private readonly ICacheService cacheService;
        private readonly ApplicationDbContext dbContext;
        public MovieService(ICacheService cacheService, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.cacheService = cacheService;
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

