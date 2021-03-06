namespace StarWarsApp.Pages.Characters
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Contracts;
    using StarWarsApp.ViewModels.Models.Characters;
    public class EditModel : PageModel
    {
        private readonly ICharacterService characterService;

        public EditModel(ICharacterService characterService)
            => this.characterService = characterService;

        public CharacterInputModel Model { get; set; }
        public void OnGet(int id)
        {
            var model = this.characterService.GetById(id);
            Model = new CharacterInputModel
            {
                Name = model.Name,
                EyeColor = model.EyeColor,
                HairColor = model.HairColor,
                Mass = model.Mass,
                SkinColor = model.HairColor,
                Gender = model.Gender,
                Height = model.Height,
                Image = model.Image
            };
        }
        public async Task<IActionResult> OnPost(CharacterInputModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await this.characterService
             .EditAsync(id, model.Name, model.HairColor, model.EyeColor, model.Height, model.Mass, model.SkinColor, model.Gender, model.Image);

            return Redirect("/Characters");
        }
    }
}
