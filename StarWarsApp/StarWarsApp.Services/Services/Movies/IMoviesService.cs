namespace StarWarsApp.Services.Services.Movies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        public MovieServiceModel GetById(int id);
        public IEnumerable<MovieServiceModel> GetAll();
        public Task DeleteAsync(int id);
    }
}
