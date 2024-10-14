using Movie.Domain.Entities;

namespace Movie.Application.Dtos.Actor
{
    public class ActorReadDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
