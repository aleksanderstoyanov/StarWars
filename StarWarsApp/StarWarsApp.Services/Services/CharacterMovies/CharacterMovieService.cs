namespace StarWarsApp.Services.Services.CharacterMovies
{
    using AutoMapper.QueryableExtensions;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterMovieService : BaseService,ICharacterMovieService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICharacterService charactersService;
        private readonly IMoviesService moviesService;

        public CharacterMovieService(ApplicationDbContext dbContext,
          ICharacterService charactersService,
          IMoviesService moviesService
         )
        {
            this.dbContext = dbContext;
            this.charactersService = charactersService;
            this.moviesService = moviesService;
        }
        public IEnumerable<CharacterServiceModel> GetCharacters(int movieId)
        {
            var currentMovie = this.moviesService.GetById(movieId);
            var movieCharacters = dbContext.CharacterMovies
               .Where(movie => movie.MovieId == currentMovie.Id)
               .Select(character => character.Character)
               .ProjectTo<CharacterServiceModel>(configuration)
               .ToList();

            return movieCharacters;
        }
    }
}
