using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.MovieGenre
{
    public class MovieGenreUpdateDto
    {
        [Required(AllowEmptyStrings = false)]
        public required Guid MovieId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public required Guid GenreId { get; set; }
    }
}
