namespace StarWarsApp.Pages.Characters
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Contracts;
    using StarWarsApp.ViewModels.Models.Characters;
    public class AddModel : PageModel
    {
        private readonly ICharacterService characterService;

        public AddModel(ICharacterService characterService)
            => this.characterService = characterService;

        public CharacterInputModel Model { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(CharacterInputModel model)
        {
            await this.characterService.CreateAsync(
                  model.Name,
                  model.HairColor,
                  model.EyeColor,
                  model.Height,
                  model.Mass,
                  model.SkinColor,
                  model.Gender,
                  model.Image);
            return Redirect("/Characters");
        }
    }
}
