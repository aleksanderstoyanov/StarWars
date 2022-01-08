namespace StarWarsApp.Services.Services.Profiles
{
    using AutoMapper;
    using StarWarsApp.Data.Data.Entities;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.Services.Services.Vehicles;
    using StarWarsApp.Services.Services.Characters;

    public class StarWarsProfile : Profile
    {
        public StarWarsProfile()
        {
            CreateMap<Character, CharacterServiceModel>();
            CreateMap<Movie, MovieServiceModel>();
            CreateMap<Vehicle, VehicleServiceModel>();
        }
    }
}
