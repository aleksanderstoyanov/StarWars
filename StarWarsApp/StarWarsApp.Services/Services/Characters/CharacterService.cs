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
        public IEnumerable<Character> GetAll()
        {
            return dbContext.Characters.ToList();
        }

        public IEnumerable<Character> GetTop3()
        {
            return dbContext.Characters.Take(3).ToList();
        }
    }
}
