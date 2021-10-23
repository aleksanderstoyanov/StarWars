namespace StarWarsApp.Services.Services.Characters
{
    using System.Collections.Generic;

    public interface ICharacterService
    {
        CharacterServiceModel GetById(int id);
        IEnumerable<CharacterServiceModel> GetAll();
        IEnumerable<CharacterServiceModel> GetTop3();
    }
}
