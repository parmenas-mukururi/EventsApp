using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Requests
{
    public class RegisterUserRequestDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")] public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
