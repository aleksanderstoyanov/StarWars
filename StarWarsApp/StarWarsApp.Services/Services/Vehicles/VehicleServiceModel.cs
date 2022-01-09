namespace StarWarsApp.Services.Services.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class VehicleServiceModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Model { get; init; }
        public string Manufacturer { get; init; }
        public int Crew { get; init; }
        public int AtmosphereSpeed { get; init; }
        public string Consumables { get; init; }
        public string Image { get; init; }
    }
}
