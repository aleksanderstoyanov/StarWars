using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarWarsApp.Services.Services.Movies;

namespace StarWarsApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMoviesService moviesService;

        public DetailsModel(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }
        public MovieServiceModel Movie { get; set; }
        public void OnGet(int id)
        {
            this.Movie = this.moviesService.GetById(id);
        }
    }
}
