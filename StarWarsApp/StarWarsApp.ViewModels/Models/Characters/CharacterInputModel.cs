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
        public string Name { get; init; }

        [Required]
        [Range(MinHeight, MaxHeight)]
        public int Height { get; init; }

        [Required]
        [Range(MinMass, MaxMass)]
        public int Mass { get; init; }

        [Required]
        [StringLength(
         MaxHairColorLength,
         MinimumLength = MinHairColorLength,
         ErrorMessage = "Hair Color should be between 3 and 40 !")]
        public string HairColor { get; init; }

        [Required]
        [StringLength(
         MaxSkinColorLength,
         MinimumLength = MinSkinColorLength,
         ErrorMessage = "Skin Color should be between 3 and 20 !")]
        public string SkinColor { get; init; }

        [Required]
        [StringLength(
         MaxEyeColor,
         MinimumLength = MinEyeColor,
         ErrorMessage = "Eye Color should be between 3 and 20 !")]
        public string EyeColor { get; init; }

        [Required]
        [StringLength(
         MaxGenderLength,
         MinimumLength = MinGenderLength,
         ErrorMessage = "Gender should be between 2 and 20 !")]
        public string Gender { get; init; }

        [Required]
        [Url(ErrorMessage = "Image should be a valid image url !")]
        public string Image { get; init; }
    }
}
