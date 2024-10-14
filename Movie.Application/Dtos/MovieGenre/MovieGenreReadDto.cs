namespace Movie.Application.Dtos.MovieGenre
{
    public class MovieGenreReadDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public Guid GenreId { get; set; }
        public string? GenreName { get; set; }
    }
}
