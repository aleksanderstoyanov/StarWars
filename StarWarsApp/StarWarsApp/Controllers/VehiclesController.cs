namespace StarWarsApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using StarWarsApp.ViewModels.Models.Api;
    using System.Linq;
    using StarWarsApp.Services.Services.Contracts;

    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
            => this.vehicleService = vehicleService;

        [HttpGet]
        public ActionResult<IEnumerable<VehiclesRequestModel>> GetAll()
            => this.vehicleService
                .GetAll()
                .Select(vehicle => new VehiclesRequestModel
                {
                    Id = vehicle.Id,
                    Name = vehicle.Name,
                    Image = vehicle.Image,
                })
                .ToList();

    }
}
