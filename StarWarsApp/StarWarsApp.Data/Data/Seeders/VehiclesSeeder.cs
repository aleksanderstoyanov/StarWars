namespace StarWarsApp.Data.Data.Seeders
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using StarWarsApp.Data.Data.Dto;
    using StarWarsApp.Data.Data.Entities;
    using StarWarsApp.Data.Data.Seeders.Contracts;

    public class VehiclesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, string rootPath)
        {
            if (context.Vehicles.Any())
            {
                return;
            }

            var jsonResult = File.ReadAllText(rootPath);
            var dtoVehicles = JsonConvert.DeserializeObject<VehicleDto[]>(jsonResult);

            var vehicles = dtoVehicles
                .Select(vehicle => new Vehicle
                {
                    Name = vehicle.Name,
                    Image = vehicle.Image,
                    Model = vehicle.Model,
                    AtmosphereSpeed = vehicle.AtmosphereSpeed,
                    Consumables = vehicle.Consumables,
                    Crew = vehicle.Crew,
                    Manufacturer = vehicle.Manufacturer
                }).ToList();

            context.AddRange(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
