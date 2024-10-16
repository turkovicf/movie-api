using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Movie.Application.Dtos.Movie
{
    public class MovieCreateDto
    {
        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public required string Title { get; set; }

        [Range(1888, 2100)]
        public required int ReleaseYear { get; set; }

        [Range(1, 600)]
        public required int Duration { get; set; }

        [MaxLength(500)]
        [Required(AllowEmptyStrings = false)]
        public required string Description { get; set; }

        [Url]
        public string? PosterUrl { get; set; }

        [Range(1, 10)]
        [AllowedValues(typeof(float), null)]
        public float? Rating { get; set; }
        public Guid? DirectorId { get; set; }

        [MaxLength(50)]
        public string? Language { get; set; }

        public List<Guid>? GenreIds { get; set; }
        public List<Guid>? ActorIds { get; set; }
    }
}
