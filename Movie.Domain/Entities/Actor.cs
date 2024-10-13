using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class Actor
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [DataType(DataType.Date)]
        public required DateTime BirthDate { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
