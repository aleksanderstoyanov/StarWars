namespace StarWarsApp.Services.Services.Movies
{
    using System.Collections.Generic;

    public interface IMoviesService
    {
        public MovieServiceModel GetById(int id);
        public IEnumerable<MovieServiceModel> GetAll();
    }
}
