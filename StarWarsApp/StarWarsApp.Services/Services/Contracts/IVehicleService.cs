namespace StarWarsApp.Services.Services.Contracts
{
    using System.Collections.Generic;
    using StarWarsApp.Services.Services.Vehicles;
    public interface IVehicleService
    {
        public IEnumerable<VehicleServiceModel> GetAll();
    }
}
