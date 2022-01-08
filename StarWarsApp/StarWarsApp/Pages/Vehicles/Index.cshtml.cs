namespace StarWarsApp.Pages.Vehicles
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using StarWarsApp.Services.Services.Vehicles;

    public class IndexModel : PageModel
    {
        private readonly IVehicleService vehicleService;

        public IndexModel(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }
        public IEnumerable<VehicleServiceModel> Vehicles { get; set; }
        public void OnGet()
        {
            this.Vehicles = this.vehicleService.GetAll();
        }
    }
}
