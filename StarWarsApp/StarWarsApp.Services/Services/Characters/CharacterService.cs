namespace StarWarsApp.Services.Services.Characters
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.Extensions.Caching.Memory;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Common.GlobalConstants;

    public class CharacterService : BaseService,ICharacterService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMemoryCache memoryCache;
   
        public CharacterService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
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
        public CharacterServiceModel GetById(int id)
        {
            var character = dbContext.Characters
                .ProjectTo<CharacterServiceModel>(configuration)
                .FirstOrDefault(character => character.Id == id);
            return character;
        }
        public IEnumerable<CharacterServiceModel> GetAll()
        {
            var characters = this.memoryCache.Get<IEnumerable<CharacterServiceModel>>(Characters_Cache_Key);
            if (characters == null)
            {
                characters = this.dbContext.Characters
                    .ProjectTo<CharacterServiceModel>(this.configuration)
                    .ToList();
                this.memoryCache.Set(Characters_Cache_Key, characters);
            }
            return characters;
        }

        public IEnumerable<CharacterServiceModel> GetTop3()
        {
            return this.dbContext.Characters
                .ProjectTo<CharacterServiceModel>(configuration)
                .Take(3);
        }
    }
}
