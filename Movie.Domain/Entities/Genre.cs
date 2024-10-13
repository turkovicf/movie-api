using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class Genre
    {

        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
