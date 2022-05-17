namespace StarWarsApp.Pages.Movies
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Contracts;
    using StarWarsApp.Services.Services.Movies;
    public class DetailsModel : PageModel
    {
        private readonly IMoviesService moviesService;

        public DetailsModel(IMoviesService moviesService)
            => this.moviesService = moviesService;

        public MovieServiceModel Movie { get; set; }
        public void OnGet(int id)
            => this.Movie = this.moviesService
            .GetById(id);

    }
}
