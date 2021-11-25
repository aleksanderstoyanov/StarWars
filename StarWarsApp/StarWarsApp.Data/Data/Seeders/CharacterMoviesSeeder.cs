using Newtonsoft.Json;
using StarWarsApp.Data.Data.Dto;
using StarWarsApp.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Data.Data.Seeders
{
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
        //public async Task SeedMovieCharacters(ApplicationDbContext context, IEnumerable<MovieDto> dtoModels)
        //{

        //}
    }
}
