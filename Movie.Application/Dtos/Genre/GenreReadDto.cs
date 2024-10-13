namespace Movie.Application.Dtos.Genre
{
    public class GenreReadDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Guid> MovieIds { get; set; } = new List<Guid>();
    }
}
