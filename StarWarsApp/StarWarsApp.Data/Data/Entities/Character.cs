using System.Collections;
using System.Collections.Generic;

namespace StarWarsApp.Data.Data.Entities
{
    public class Character
    {
        public Character()
        {
            this.CharacterMovies = new HashSet<CharacterMovie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public ICollection<CharacterMovie> CharacterMovies { get; set; }
    }
}
