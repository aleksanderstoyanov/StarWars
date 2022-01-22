namespace StarWarsApp.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Contracts;
    using StarWarsApp.ViewModels.Models.Characters;
    using System.Collections.Generic;
    using System.Linq;
    public class IndexModel : PageModel
    {
        private readonly ICharacterService characterService;

        public IndexModel(ICharacterService characterService)
        {
            this.characterService = characterService;
        }
        public List<HomeCharacterViewModel> Characters { get; set; }
        public void OnGet()
        {
            Characters = this.characterService.GetTop3()
                .Select(character => new HomeCharacterViewModel
                {
                    Id = character.Id,
                    Name = character.Name,
                    Image = character.Image
                }).ToList();
        }
    }
}
