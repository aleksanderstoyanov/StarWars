namespace StarWarsApp.Services.Services.Characters
{
    using StarWarsApp.Data.Data.Entities;
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
