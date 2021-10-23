namespace StarWars.Services.Characters
{
    using StarWars.Data;
    using StarWars.Data.Entities;
    using System;
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
        public IEnumerable<Character> GetAll()
        {
            return this.dbContext.Characters.ToList();
        }

        public IEnumerable<Character> GetTop3()
        {
            return this.dbContext.Characters.Take(3).ToList();
        }
    }
}
