namespace StarWarsApp.Services.Services.Movies
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.Extensions.Caching.Memory;
    using StarWarsApp.Data.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static Common.GlobalConstants;
    public class MovieService :BaseService, IMoviesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMemoryCache memoryCache;

        public MovieService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
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

            var movies = this.memoryCache.Get<IEnumerable<MovieServiceModel>>(Movies_Cache_Key);
            if (movies == null)
            {
                movies = this.dbContext.Movies
                    .ProjectTo<MovieServiceModel>(configuration)
                    .ToList();
                this.memoryCache.Set(Movies_Cache_Key, movies, TimeSpan.FromMinutes(30));
            }
            return movies;
        }
    }
}

