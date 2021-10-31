namespace StarWarsApp.Services.Services.Movies
{
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MovieService : IMoviesService
    {
        private readonly ApplicationDbContext dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<MovieServiceModel> GetAll()
        {
            return MapMovies(this.dbContext.Movies.AsQueryable());
        }
        private IEnumerable<MovieServiceModel> MapMovies(IQueryable<Movie> movies)
        {
            return movies
                .Select(movie => new MovieServiceModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Director = movie.Director,
                    Producer = movie.Producer,
                    Image = movie.Image,
                    ReleaseDate= movie.ReleaseDate,
                    EpisodeId = movie.EpisodeId
                }).ToList();
        }
    }
}
}
