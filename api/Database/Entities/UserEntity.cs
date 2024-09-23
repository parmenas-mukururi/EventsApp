using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities
{

    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime? PasswordResetExpiry { get; set; }
        public string? PasswordResetToken { get; set; }

        public List<UserRolesEntity> UserRoles { get; set; }

    }
}
