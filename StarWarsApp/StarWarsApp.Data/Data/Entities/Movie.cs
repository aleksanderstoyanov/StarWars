using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Data.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public string Image { get; set; }
    }
}
