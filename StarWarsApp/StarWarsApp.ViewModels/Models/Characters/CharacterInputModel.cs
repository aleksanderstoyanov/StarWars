namespace StarWarsApp.ViewModels.Models.Characters
{
    using System.ComponentModel.DataAnnotations;
    using static StarWarsApp.Common.GlobalConstants.Characters;
    public class CharacterInputModel
    {
        [Required]
        [StringLength(
         MaxNameLength,
         MinimumLength = MinNameLength,
         ErrorMessage = "Name should be between 2 and 50 !")]
        public string Name { get; set; }

        [Required]
        [Range(MinHeight, MaxHeight)]
        public int Height { get; set; }

        [Required]
        [Range(MinMass, MaxMass)]
        public int Mass { get; set; }

        [Required]
        [StringLength(
         MaxHairColorLength,
         MinimumLength = MinHairColorLength,
         ErrorMessage = "Hair Color should be between 3 and 40 !")]
        public string HairColor { get; set; }

        [Required]
        [StringLength(
         MaxSkinColorLength,
         MinimumLength = MinSkinColorLength,
         ErrorMessage = "Skin Color should be between 3 and 20 !")]
        public string SkinColor { get; set; }

        [Required]
        [StringLength(
         MaxEyeColor,
         MinimumLength = MinEyeColor,
         ErrorMessage = "Eye Color should be between 3 and 20 !")]
        public string EyeColor { get; set; }

        [Required]
        [StringLength(
         MaxGenderLength,
         MinimumLength = MinGenderLength,
         ErrorMessage = "Gender should be between 2 and 20 !")]
        public string Gender { get; set; }

        [Required]
        [Url(ErrorMessage = "Image should be a valid image url !")]
        public string Image { get; set; }
    }
}
