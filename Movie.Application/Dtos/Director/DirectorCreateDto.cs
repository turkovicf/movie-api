using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.Director
{
    public class DirectorCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Director name cannot be empty.")]
        [MaxLength(100)]
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
