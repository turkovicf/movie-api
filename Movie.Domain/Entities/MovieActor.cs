using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class MovieActor
    {
        [Key]
        public Guid Id { get; set; }

        public required Guid MovieId { get; set; }
        public required Guid ActorId { get; set; }

        public Actor? Actor { get; set; }
        public Movie? Movie { get; set; }
    }
}
