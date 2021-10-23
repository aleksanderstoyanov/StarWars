namespace StarWars.Services.Characters
{
    using StarWars.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICharacterService
    {
        IEnumerable<Character> GetAll();
        IEnumerable<Character> GetTop3();
    }
}
