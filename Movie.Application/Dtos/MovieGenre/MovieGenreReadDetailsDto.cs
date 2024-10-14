using Movie.Application.Dtos.Genre;
using Movie.Application.Dtos.Movie;

namespace Movie.Application.Dtos.MovieGenre
{
    public class MovieGenreReadDetailsDto
    {
        public Guid Id { get; set; }
        public MovieReadDto Movie { get; set; }
        public GenreReadDto Genre { get; set; }
    }
}
