using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class MovieGenre
    {
        [Key]
        public Guid Id { get; set; }

        public required Guid MovieId { get; set; }
        public required Guid GenreId { get; set; }

        public Movie? Movie { get; set; }
        public Genre? Genre { get; set; }
    }
}
