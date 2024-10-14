using Movie.Application.Dtos.Actor;
using Movie.Application.Dtos.Genre;

namespace Movie.Application.Dtos.Movie
{
    public class MovieReadDetailsDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string? PosterUrl { get; set; }
        public float Rating { get; set; }
        public Guid DirectorId { get; set; }
        public string? Language { get; set; }

        public List<GenreReadDto>? Genres { get; set; }
        public List<ActorReadDto>? Actors { get; set; }
        
    }
}
