namespace StarWarsApp.Services.Services.Movies
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    public interface IMoviesService
    {
        public MovieServiceModel GetById(int id);
        public IEnumerable<MovieServiceModel> GetAll();
        public Task DeleteAsync(int id);
    }
}
