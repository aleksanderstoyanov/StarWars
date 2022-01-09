namespace StarWarsApp.Data.Data.Seeders
{
    using System.Linq;
    using System.Threading.Tasks;
    using StarWarsApp.Data.Data.Dto;
    using System.Collections.Generic;
    using StarWarsApp.Data.Data.Entities;
    public static class CharacterMoviesSeeder
    {
        public static async Task SeedCharacterMovies(ApplicationDbContext context, IEnumerable<CharacterDto> dtoModels)
        {
            foreach (var model in dtoModels)
            {
                var currentCharacter = context.Characters
                 .FirstOrDefault(character => character.Name == model.Name);
                foreach (var episode in model.Episodes)
                {
                    var currentMovie = context.Movies
                        .FirstOrDefault(movie => movie.EpisodeId == episode);

                    currentCharacter.CharacterMovies
                        .Add(new CharacterMovie()
                        {
                            CharacterId = currentCharacter.Id,
                            Character = currentCharacter,
                            MovieId = currentMovie.Id,
                            Movie = currentMovie
                        });
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
