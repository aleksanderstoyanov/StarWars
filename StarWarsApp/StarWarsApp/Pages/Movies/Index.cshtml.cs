namespace StarWarsApp.Pages.Movies
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.ViewModels.Models.Movies;

    public class IndexModel : PageModel
    {
        private readonly IMoviesService moviesService;

        public IndexModel(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        public IEnumerable<HomeMovieViewModel> Movies { get; set; }
        public void OnGet()
        {
            this.Movies = this.moviesService.GetAll()
                .Select(movie => new HomeMovieViewModel
                {
                    Id = movie.Id,
                    Image = movie.Image
                });
        }
        public async Task<ActionResult> OnGetDelete(int id) {
            await this.moviesService.DeleteAsync(id);
            return Redirect("/Movies");
        }
    }
}
