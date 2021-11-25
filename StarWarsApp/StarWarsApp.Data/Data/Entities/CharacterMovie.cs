namespace StarWarsApp.Data.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CharacterMovie
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
