using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.MovieActor
{
    public class MovieActorUpdateDto
    {
        [Required(AllowEmptyStrings = false)]
        public required Guid MovieId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public required Guid ActorId { get; set; }
    }
}
