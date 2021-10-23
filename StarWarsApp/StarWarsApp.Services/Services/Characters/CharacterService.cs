namespace StarWarsApp.Services.Services.Characters
{
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext dbContext;

        public CharacterService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public CharacterServiceModel GetById(int id)
        {
            var character = dbContext.Characters
                .FirstOrDefault(character => character.Id == id);
            return new CharacterServiceModel
            {
                Id = character.Id,
                Name = character.Name,
                Height = character.Height,
                Gender = character.Gender,
                EyeColor = character.EyeColor,
                HairColor = character.HairColor,
                Image = character.Image,
                SkinColor = character.SkinColor,
                Mass = character.Mass
            };
        }
        public IEnumerable<CharacterServiceModel> GetAll()
        {
            return MapCharacters(this.dbContext.Characters.AsQueryable());
        }

        public IEnumerable<CharacterServiceModel> GetTop3()
        {
            return MapCharacters(this.dbContext.Characters.Take(3));
        }

        private IEnumerable<CharacterServiceModel> MapCharacters(IQueryable<Character> characters)
        {
            return characters
                .Select(character => new CharacterServiceModel
                {
                    Id = character.Id,
                    Name = character.Name,
                    Height = character.Height,
                    Gender = character.Gender,
                    EyeColor = character.EyeColor,
                    HairColor = character.HairColor,
                    Image = character.Image,
                    SkinColor = character.SkinColor,
                    Mass = character.Mass
                }).ToList();
        }
        public async Task CreateAsync(string name, string hairColor, string eyeColor, int height, int mass, string skinColor, string gender, string image)
        {
            this.dbContext.Add(new Character
            {
                Name = name,
                Image = image,
                EyeColor = eyeColor,
                HairColor = hairColor,
                SkinColor = skinColor,
                Gender = gender,
                Height = height,
                Mass = mass,

            });
            await this.dbContext.SaveChangesAsync();
        }
    }
}
