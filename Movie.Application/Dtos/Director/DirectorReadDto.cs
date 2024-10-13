using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.Director
{
    public class DirectorReadDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Guid> MovieIds { get; set; } = new List<Guid>();
    }
}
