using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.Actor
{
    public class ActorCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Actor name cannot be empty.")]
        [MaxLength(50)]
        public required string Name { get; set; }
        public required DateTime BirthDate { get; set; }
    }
}
