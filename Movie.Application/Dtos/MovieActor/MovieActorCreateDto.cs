namespace Movie.Application.Dtos.MovieActor
{
    public class MovieActorCreateDto
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
    }
}
