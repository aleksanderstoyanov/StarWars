namespace StarWarsApp.Services.Services
{
    using AutoMapper;
    using StarWarsApp.Services.Services.Profiles;
    public abstract class BaseService
    {
        protected MapperConfiguration configuration = new MapperConfiguration(cfg =>
             cfg.AddProfile(new StarWarsProfile()));
    }
}
