using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.Actor
{
    public class ActorUpdateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Actor name cannot be empty.")]
        [MaxLength(100)]
        public required string Name { get; set; }
        public required DateTime BirthDate { get; set; }
    }
}
