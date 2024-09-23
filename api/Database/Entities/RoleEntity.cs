using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities
{
    [Table("Role")]
    public class RoleEntity : BaseEntity
    {
        public Guid RoleId { get; set; }
        public required string RoleName { get; set; }
        public List<UserRolesEntity> UserRoles { get; set; }
    }
}
