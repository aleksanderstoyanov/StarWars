namespace StarWarsApp.Services.Services.Movies
{
    using Microsoft.Extensions.Caching.Memory;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static Common.GlobalConstants;
    public class MovieService : IMoviesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMemoryCache memoryCache;

        public MovieService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
        }
        public IEnumerable<MovieServiceModel> GetAll()
        {
  
            var movies = this.memoryCache.Get<IEnumerable<MovieServiceModel>>(Movies_Cache_Key);
            if (movies == null)
            {
                movies = MapMovies(this.dbContext.Movies.AsQueryable());
                this.memoryCache.Set(Movies_Cache_Key, movies, TimeSpan.FromMinutes(30));
            }
            return movies;
        }
        private IEnumerable<MovieServiceModel> MapMovies(IQueryable<Movie> movies)
        {
            return movies
                .Select(movie => new MovieServiceModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Director = movie.Director,
                    Producer = movie.Producer,
                    Image = movie.Image,
                    ReleaseDate = movie.ReleaseDate,
                    EpisodeId = movie.EpisodeId
                }).ToList();
        }
    }
}

