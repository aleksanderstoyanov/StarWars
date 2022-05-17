namespace StarWarsApp.Services.Services.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using StarWarsApp.Services.Services.Movies;
    public interface IMoviesService
    {
        public MovieServiceModel GetById(int id);
        public IEnumerable<MovieServiceModel> GetAll();
        public Task DeleteAsync(int id);
    }
}
