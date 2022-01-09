namespace StarWarsApp.Services.Services.Cache
{
    using System.Collections.Generic;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.Services.Services.Vehicles;
    using StarWarsApp.Services.Services.Characters;
    public interface ICacheService
    {
        IEnumerable<MovieServiceModel> GetCachedMovies();
        IEnumerable<VehicleServiceModel> GetCachedVehicles();
        IEnumerable<CharacterServiceModel> GetCachedCharacters();
    }
}
