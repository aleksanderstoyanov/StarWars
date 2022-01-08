namespace StarWarsApp.Data.Data.Dto
{
    using Newtonsoft.Json;
    public class VehicleDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Crew { get; set; }
        [JsonProperty("max_atmosphering_speed")]
        public int AtmosphereSpeed { get; set; }
        public string Consumables { get; set; }
        public string Image { get; set; }
    }
}
