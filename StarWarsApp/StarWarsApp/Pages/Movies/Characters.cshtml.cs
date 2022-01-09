namespace StarWarsApp.Pages.Movies
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.CharacterMovies;
    using StarWarsApp.ViewModels.Models.Characters;
    public class CharactersModel : PageModel
    {
        private readonly ICharacterMovieService characterMovieService;

        public CharactersModel(ICharacterMovieService characterMovieService)
            => this.characterMovieService = characterMovieService;

        public IEnumerable<AllCharactersViewModel> Characters { get; set; }
        public void OnGet(int id)
          => Characters = this.characterMovieService
               .GetCharacters(id)
               .Select(character => new AllCharactersViewModel
               {
                   Id = character.Id,
                   Image = character.Image
               })
               .ToList();

    }
}
