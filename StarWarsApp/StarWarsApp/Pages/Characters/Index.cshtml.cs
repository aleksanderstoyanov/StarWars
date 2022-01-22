namespace StarWarsApp.Pages.Characters
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.ViewModels.Models.Characters;
    using StarWarsApp.Services.Services.Contracts;

    public class IndexModel : PageModel
    {
        private readonly ICharacterService characterService;

        public IndexModel(ICharacterService characterService)
            => this.characterService = characterService;
        public IEnumerable<AllCharactersViewModel> Characters { get; set; }
        public void OnGet()
            => Characters = this.characterService
                .GetAll()
                .Select(character => new AllCharactersViewModel
                {
                    Id = character.Id,
                    Image = character.Image
                })
                .ToList();

        public async Task<ActionResult> OnGetDelete(int id)
        {
            await this.characterService.DeleteAsync(id);
            return Redirect("/Characters");
        }
    }
}
