namespace StarWarsApp.Pages.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Movies;
    public class IndexModel : PageModel
    {
        private readonly IMoviesService moviesService;

        public IndexModel(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        public IEnumerable<MovieServiceModel> Movies { get; set; }
        public void OnGet()
        {
            this.Movies = this.moviesService.GetAll();
        }
    }
}
