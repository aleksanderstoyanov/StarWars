namespace StarWarsApp.Services.Services.Cache
{
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    using System.Collections.Generic;

    public interface ICacheService
    {
        IEnumerable<MovieServiceModel> GetCachedMovies();
        IEnumerable<CharacterServiceModel> GetCachedCharacters();
    }
}
