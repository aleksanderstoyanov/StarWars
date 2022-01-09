namespace StarWarsApp.Services.Services.Characters
{
    using AutoMapper.QueryableExtensions;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using StarWarsApp.Services.Services.Cache;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class CharacterService : BaseService, ICharacterService
    {
        private readonly ICacheService cacheService;
        private readonly ApplicationDbContext dbContext;
        public CharacterService(ICacheService cacheService, ApplicationDbContext dbContext)
        {
            this.cacheService = cacheService;
            this.dbContext = dbContext;
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
        public async Task EditAsync(int id, string name, string hairColor, string eyeColor, int height, int mass, string skinColor, string gender, string image)
        {
            var character = this.dbContext
            .Characters.FirstOrDefault(character => character.Id == id);

            character.Name = name;
            character.HairColor = hairColor;
            character.EyeColor = eyeColor;
            character.Height = height;
            character.Mass = mass;
            character.SkinColor = skinColor;
            character.Gender = gender;
            character.Image = image;

            await this.dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var character = this.dbContext.Characters
                .FirstOrDefault(character => character.Id == id);
            if (character != null)
            {
                character.isDeleted = true;
            }
            await this.dbContext.SaveChangesAsync();
        }
        public CharacterServiceModel GetById(int id)
             => this.dbContext
                 .Characters
                 .ProjectTo<CharacterServiceModel>(configuration)
                 .FirstOrDefault(character => character.Id == id);

        public IEnumerable<CharacterServiceModel> GetAll()
            => this.cacheService
                .GetCachedCharacters();

        public IEnumerable<CharacterServiceModel> GetTop3()
            => this.dbContext
                .Characters
                .ProjectTo<CharacterServiceModel>(configuration)
                .Take(3);

    }
}
