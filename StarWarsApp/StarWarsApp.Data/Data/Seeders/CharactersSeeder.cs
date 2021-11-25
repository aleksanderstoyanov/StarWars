namespace StarWarsApp.Data.Data.Seeders
{
    using Newtonsoft.Json;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Dto;
    using StarWarsApp.Data.Data.Entities;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    public class CharactersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, string rootPath)
        {
            if (context.Characters.Any())
            {
                return;
            }
            var jsonResult = File.ReadAllText(rootPath);
            var dtoModels = JsonConvert.DeserializeObject<CharacterDto[]>(jsonResult);
            var characters = dtoModels
                .Select(character => new Character
                {
                    Name = character.Name,
                    Mass = character.Mass,
                    EyeColor = character.EyeColor,
                    SkinColor = character.SkinColor,
                    Gender = character.Gender,
                    Height = character.Height,
                    HairColor = character.HairColor,
                    Image = character.Image
                });
            context.Characters.AddRange(characters);
            await context.SaveChangesAsync();
            await CharacterMoviesSeeder.SeedCharacterMovies(context, dtoModels);
        }
    }
}
