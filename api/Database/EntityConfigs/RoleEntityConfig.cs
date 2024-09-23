using api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace api.Database.EntityConfigs
{
    public class RoleEntityConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Role");
            builder.Property(r => r.RoleId).ValueGeneratedOnAdd();  
            builder.Property(r => r.Id).ValueGeneratedOnAdd();  
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.RowVersion);
            builder.HasIndex(r => r.RoleId).IsClustered(false).HasDatabaseName("IX_Role_RoleId").IsUnique();
            builder.HasIndex(r=>r.RoleName).IsClustered(false).HasDatabaseName("IX_Role_RoleName").IsUnique();

        }
    }
}
