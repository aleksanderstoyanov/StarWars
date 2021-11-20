namespace StarWarsApp.Services.Services.Profiles
{
    using AutoMapper;
    using StarWarsApp.Data.Data.Entities;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    public class StarWarsProfile : Profile
    {
        public StarWarsProfile()
        {
            CreateMap<Character, CharacterServiceModel>();
            CreateMap<Movie, MovieServiceModel>();
        }
    }
}
