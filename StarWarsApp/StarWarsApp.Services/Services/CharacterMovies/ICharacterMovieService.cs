namespace StarWarsApp.Services.Services.CharacterMovies
{
    using System.Collections.Generic;
    using StarWarsApp.Services.Services.Characters;
    public interface ICharacterMovieService
    {
        public IEnumerable<CharacterServiceModel> GetCharacters(int movieId);
    }
}
