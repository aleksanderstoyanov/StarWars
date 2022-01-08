namespace StarWarsApp.Services.Services.Cache
{
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.Services.Services.Vehicles;
    using System.Collections.Generic;

    public interface ICacheService
    {
        IEnumerable<MovieServiceModel> GetCachedMovies();
        IEnumerable<VehicleServiceModel> GetCachedVehicles();
        IEnumerable<CharacterServiceModel> GetCachedCharacters();
    }
}
