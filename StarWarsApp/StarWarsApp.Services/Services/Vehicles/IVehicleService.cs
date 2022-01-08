namespace StarWarsApp.Services.Services.Vehicles
{
    using System.Collections.Generic;

    public interface IVehicleService
    {
        public IEnumerable<VehicleServiceModel> GetAll();
    }
}
