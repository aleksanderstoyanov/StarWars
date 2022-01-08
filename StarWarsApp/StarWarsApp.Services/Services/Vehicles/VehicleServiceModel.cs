namespace StarWarsApp.Services.Services.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class VehicleServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Crew { get; set; }
        public int AtmosphereSpeed { get; set; }
        public string Consumables { get; set; }
        public string Image { get; set; }
    }
}
