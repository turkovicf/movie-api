namespace Movie.Application.Dtos.Movie
{
    public class MovieCreateDto
    {
        public string? Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string? PosterUrl { get; set; }
        public float Rating { get; set; }
        public Guid? DirectorId { get; set; }
        public string? Language { get; set; }

        public List<Guid>? GenreIds { get; set; }
        public List<Guid>? ActorIds { get; set; }
    }
}
