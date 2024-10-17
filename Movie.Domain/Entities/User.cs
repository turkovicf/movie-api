using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public required string Role { get; set; } = "User";
    }
}
