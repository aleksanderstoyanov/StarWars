namespace StarWarsApp.Data.Data.Dto
{
    using Newtonsoft.Json;

    public class CharacterDto
    {
        public string Name { get; init; }
        public int Height { get; init; }
        public int Mass { get; init; }
        [JsonProperty("hair_color")]
        public string HairColor { get; init; }
        [JsonProperty("skin_color")]
        public string SkinColor { get; init; }
        [JsonProperty("eye_color")]
        public string EyeColor { get; init; }
        public string Gender { get; init; }
        public string Image { get; init; }
        public int[] Episodes { get; init; }
    }
}
