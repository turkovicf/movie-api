using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public required string Title { get; set; }

        [Range(1888, 2100)]
        public required int ReleaseYear { get; set; }

        [Range(1, 600)]
        public required int Duration { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }

        [Url]
        public string? PosterUrl { get; set; }

        [Range(1, 10)]
        public float? Rating { get; set; }

        public required Guid DirectorId { get; set; }

        [MaxLength(50)]
        public string? Language { get; set; }

        // Navigation properties
        public Director? Director { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
