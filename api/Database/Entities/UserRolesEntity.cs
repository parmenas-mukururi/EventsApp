using System.ComponentModel.DataAnnotations.Schema;

namespace api.Database.Entities
{
    [Table("UserRoles")]
    public class UserRolesEntity : BaseEntity
    {
        public Guid UserRoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public UserEntity User{ get; set; }

        public RoleEntity Role{ get; set; }


    }
}
