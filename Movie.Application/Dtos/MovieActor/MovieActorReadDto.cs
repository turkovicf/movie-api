namespace Movie.Application.Dtos.MovieActor
{
    public class MovieActorReadDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public Guid ActorId { get; set; }
        public string? ActorName { get; set; }
    }
}
