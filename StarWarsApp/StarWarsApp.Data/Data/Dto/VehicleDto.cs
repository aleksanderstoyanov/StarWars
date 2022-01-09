namespace StarWarsApp.Data.Data.Dto
{
    using Newtonsoft.Json;
    public class VehicleDto
    {
        public string Name { get; init; }
        public string Model { get; init; }
        public string Manufacturer { get; init; }
        public int Crew { get; init; }
        [JsonProperty("max_atmosphering_speed")]
        public int AtmosphereSpeed { get; init; }
        public string Consumables { get; init; }
        public string Image { get; init; }
    }
}
