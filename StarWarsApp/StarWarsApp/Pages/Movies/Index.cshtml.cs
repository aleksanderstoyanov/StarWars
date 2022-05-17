namespace StarWarsApp.Pages.Movies
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.ViewModels.Models.Movies;
    using StarWarsApp.Services.Services.Contracts;

    public class IndexModel : PageModel
    {
        private readonly IMoviesService moviesService;

        public IndexModel(IMoviesService moviesService)
            => this.moviesService = moviesService;

        public IEnumerable<HomeMovieViewModel> Movies { get; set; }
        public void OnGet()
          => this.Movies = this.moviesService
              .GetAll()
              .Select(movie => new HomeMovieViewModel
              {
                  Id = movie.Id,
                  Image = movie.Image
              });

        public async Task<ActionResult> OnGetDelete(int id)
        {
            await this.moviesService.DeleteAsync(id);
            return Redirect("/Movies");
        }
    }
}
