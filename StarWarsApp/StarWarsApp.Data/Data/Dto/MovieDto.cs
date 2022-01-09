using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Data.Data.Dto
{
    public class MovieDto
    {
        public string Title { get; init; }
        [JsonProperty("episode_id")]
        public int EpisodeId { get; init; }
        [JsonProperty("opening_crawl")]
        public string Description { get; init; }
        public string Director { get; init; }
        public string Producer { get; init; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; init; }
        public string Image { get; init; }
        public int[] Characters { get; init; }
    }
}
