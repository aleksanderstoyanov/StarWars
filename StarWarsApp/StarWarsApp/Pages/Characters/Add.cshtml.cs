namespace StarWarsApp.Pages.Characters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.ViewModels.Models.Characters;
    using System.Threading.Tasks;

    public class AddModel : PageModel
    {
        private readonly ICharacterService characterService;

        public AddModel(ICharacterService characterService)
        {
            this.characterService = characterService;
        }
        public CharacterInputModel Model { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CharacterInputModel model)
        {
            await this.characterService
             .CreateAsync(model.Name, model.HairColor, model.EyeColor, model.Height, model.Mass, model.SkinColor, model.Gender, model.Image);
            return Redirect("/Characters");
        }
    }
}
