namespace StarWarsApp.Services.Services.CharacterMovies
{
    using System.Linq;
    using StarWarsApp.Data.Data;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Contracts;

    public class CharacterMovieService : BaseService,ICharacterMovieService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMoviesService moviesService;

        public CharacterMovieService(ApplicationDbContext dbContext, IMoviesService moviesService)
        {
            this.dbContext = dbContext;
            this.moviesService = moviesService;
        }
        public IEnumerable<CharacterServiceModel> GetCharacters(int movieId)
        {
            var currentMovie = this.moviesService.GetById(movieId);
            var movieCharacters = dbContext.CharacterMovies
               .Where(movie => movie.MovieId == currentMovie.Id && !movie.Character.isDeleted)
               .Select(character => character.Character)
               .ProjectTo<CharacterServiceModel>(configuration)
               .ToList();

            return movieCharacters;
        }
    }
}
