namespace StarWarsApp.Data.Data.Dto
{
    using Newtonsoft.Json;

    public class CharacterDto
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }
        [JsonProperty("hair_color")]
        public string HairColor { get; set; }
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
    }
}
