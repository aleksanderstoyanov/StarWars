namespace StarWars.Data.Seeders
{
    using Newtonsoft.Json;
    using StarWars.Data.Dto;
    using StarWars.Data.Entities;
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
            var models = JsonConvert.DeserializeObject<CharacterDto[]>(jsonResult)
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
            context.Characters.AddRange(models);
            await context.SaveChangesAsync();

        }
    }
}
