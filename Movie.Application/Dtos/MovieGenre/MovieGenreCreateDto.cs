using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.MovieGenre
{
    public class MovieGenreCreateDto
    {
        [Required(AllowEmptyStrings = false)]
        public required Guid MovieId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public required Guid GenreId {  get; set; }
    }
}
