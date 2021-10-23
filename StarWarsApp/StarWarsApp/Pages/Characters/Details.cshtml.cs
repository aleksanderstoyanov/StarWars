namespace StarWarsApp.Pages.Characters
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.ViewModels.Models.Characters;

    public class DetailsModel : PageModel
    {
        private readonly ICharacterService characterService;

        public DetailsModel(ICharacterService characterService)
        {
            this.characterService = characterService;
        }
        public DetailsCharacterViewModel Character { get; set; }
        public void OnGet(int id)
        {
            var character = this.characterService.GetById(id);
            Character = new DetailsCharacterViewModel
            {
                Name = character.Name,
                Height = character.Height,
                Gender = character.Gender,
                EyeColor = character.EyeColor,
                HairColor = character.HairColor,
                Image = character.Image,
                SkinColor = character.SkinColor,
                Mass = character.Mass
            };
        }
    }
}
