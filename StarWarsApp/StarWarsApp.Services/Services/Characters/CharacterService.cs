namespace StarWarsApp.Services.Services.Characters
{
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext dbContext;

        public CharacterService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<CharacterServiceModel> GetAll()
        {
            return MapCharacters(this.dbContext.Characters.AsQueryable());
        }

        public IEnumerable<CharacterServiceModel> GetTop3()
        {
            return  MapCharacters(this.dbContext.Characters.Take(3));
        }

        private IEnumerable<CharacterServiceModel> MapCharacters(IQueryable<Character> characters)
        {
            return characters
                .Select(character => new CharacterServiceModel
                {
                    Name=character.Name,
                    Height=character.Height,
                    Gender=character.Gender,
                    EyeColor=character.EyeColor,
                    HairColor=character.HairColor,
                    Image=character.Image,
                    SkinColor=character.SkinColor,
                    Mass=character.Mass
                }).ToList();
        }
    }
}
