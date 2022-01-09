namespace StarWarsApp.Services.Services.Movies
{
    public class MovieServiceModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int EpisodeId { get; init; }
        public string Description { get; init; }
        public string Director { get; init; }
        public string Producer { get; init; }
        public string ReleaseDate { get; init; }
        public string Image { get; init; }
    }
}
