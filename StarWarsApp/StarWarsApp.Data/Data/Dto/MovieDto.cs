﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Data.Data.Dto
{
    public class MovieDto
    {
        public string Title { get; set; }
        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }
        [JsonProperty("opening_crawl")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        public string Image { get; set; }
        public int[] Characters { get; set; }
    }
}
