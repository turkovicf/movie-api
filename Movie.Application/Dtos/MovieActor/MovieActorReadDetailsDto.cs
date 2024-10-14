using Movie.Application.Dtos.Actor;
using Movie.Application.Dtos.Movie;

namespace Movie.Application.Dtos.MovieActor
{
    public class MovieActorReadDetailsDto
    {
        public Guid Id { get; set; }
        public MovieReadDto Movie { get; set; }
        public ActorReadDto Actor { get; set; }
    }
}
