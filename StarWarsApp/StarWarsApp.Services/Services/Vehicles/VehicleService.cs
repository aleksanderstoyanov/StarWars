namespace StarWarsApp.Services.Services.Vehicles
{
    using System.Collections.Generic;
    using StarWarsApp.Services.Services.Cache;

    public class VehicleService : IVehicleService
    {
        private readonly ICacheService cacheService;

        public VehicleService(ICacheService cacheService)
            => this.cacheService = cacheService;

        public IEnumerable<VehicleServiceModel> GetAll()
            => this.cacheService
                .GetCachedVehicles();

    }
}
