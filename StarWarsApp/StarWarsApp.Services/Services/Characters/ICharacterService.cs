namespace StarWarsApp.Services.Services.Characters
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICharacterService
    {
        CharacterServiceModel GetById(int id);
        IEnumerable<CharacterServiceModel> GetAll();
        IEnumerable<CharacterServiceModel> GetTop3();
        public Task CreateAsync(string name, string hairColor, string eyeColor, int height, int mass, string skinColor, string gender, string image);
        public Task EditAsync(int id, string name, string hairColor, string eyeColor, int height, int mass, string skinColor, string gender, string image);
        public Task DeleteAsync(int id);
    }
}
