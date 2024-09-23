using api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Database.EntityConfigs
{
    public class UserRoleEntityConfig : IEntityTypeConfiguration<UserRolesEntity>
    {
        public void Configure(EntityTypeBuilder<UserRolesEntity> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(ur => ur.UserRoleId);
            builder.Property(ur => ur.RowVersion);
            builder.Property(ur=>ur.Id).ValueGeneratedOnAdd();
            builder.HasIndex(ur=>ur.UserRoleId).IsClustered(false).IsUnique().HasDatabaseName("IX_UserRole_UserRoleId");
            builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).HasConstraintName("FK_UserRole_User_UserId");
            builder.HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId).HasConstraintName("FK_UserRole_Role_RoleId");
        }
    }
}
