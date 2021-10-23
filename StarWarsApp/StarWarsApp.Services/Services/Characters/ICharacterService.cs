namespace StarWarsApp.Services.Services.Characters
{
    using System.Collections.Generic;

    public interface ICharacterService
    {
        IEnumerable<CharacterServiceModel> GetAll();
        IEnumerable<CharacterServiceModel> GetTop3();
    }
}
