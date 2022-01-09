namespace StarWarsApp.Services.Services.Characters
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
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
