namespace StarWarsApp.Services.Services.Cache
{
    using System;
    using System.Linq;
    using StarWarsApp.Data.Data;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using Microsoft.Extensions.Caching.Memory;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.Services.Services.Vehicles;
    using StarWarsApp.Services.Services.Characters;
    using static StarWarsApp.Common.GlobalConstants;
    using StarWarsApp.Services.Services.Contracts;

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
                    .Where(movie => !movie.isDeleted)
                    .ProjectTo<MovieServiceModel>(configuration)
                    .ToList();
                this.memoryCache.Set(Movies_Cache_Key, movies, TimeSpan.FromSeconds(1));
            }
            return movies;
        }

        public IEnumerable<VehicleServiceModel> GetCachedVehicles()
        {
            var vehicles = this.memoryCache.Get<IEnumerable<VehicleServiceModel>>(Vehicles_Cache_Key);
            if (vehicles == null)
            {
                vehicles = this.dbContext.Vehicles
                    .ProjectTo<VehicleServiceModel>(configuration)
                    .ToList();
                this.memoryCache.Set(Vehicles_Cache_Key, vehicles, TimeSpan.FromSeconds(1));
            }
            return vehicles;
        }
    }
}
