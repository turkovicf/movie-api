using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.User
{
    public class UserUpdateDto
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        public required string Username { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
