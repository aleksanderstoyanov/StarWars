using AutoMapper;
using StarWarsApp.Data.Data.Entities;
using StarWarsApp.Services.Services.Characters;
using StarWarsApp.Services.Services.Movies;

namespace StarWarsApp.Infrastructure.Profiles
{
    public class StarWarsProfile : Profile
    {
        public StarWarsProfile()
        {
            CreateMap<Character, CharacterServiceModel>();
            CreateMap<Movie, MovieServiceModel>();
        }
    }
}
