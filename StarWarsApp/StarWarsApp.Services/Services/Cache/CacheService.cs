namespace StarWarsApp.Services.Services.Cache
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.Extensions.Caching.Memory;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static StarWarsApp.Common.GlobalConstants;
    public class CacheService : BaseService, ICacheService
    {
        private readonly IMemoryCache memoryCache;
        private readonly ApplicationDbContext dbContext;

        public CacheService(IMemoryCache memoryCache, ApplicationDbContext dbContext)
        {
            this.memoryCache = memoryCache;
            this.dbContext = dbContext;
        }
        public IEnumerable<CharacterServiceModel> GetCachedCharacters()
        {
            var characters = this.memoryCache.Get<IEnumerable<CharacterServiceModel>>(Characters_Cache_Key);
            if (characters == null)
            {
                characters = this.dbContext.Characters
                    .Where(character => !character.isDeleted)
                    .ProjectTo<CharacterServiceModel>(configuration)
                    .ToList();
                this.memoryCache.Set(Characters_Cache_Key, characters, TimeSpan.FromSeconds(1));
            }
            return characters;
        }
        public IEnumerable<MovieServiceModel> GetCachedMovies()
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
