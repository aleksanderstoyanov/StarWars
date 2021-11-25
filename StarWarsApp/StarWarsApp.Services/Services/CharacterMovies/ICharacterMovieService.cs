namespace StarWarsApp.Services.Services.CharacterMovies
{
    using StarWarsApp.Services.Services.Characters;
    using System.Collections.Generic;

    public interface ICharacterMovieService
    {
        public IEnumerable<CharacterServiceModel> GetCharacters(int movieId);
    }
}
