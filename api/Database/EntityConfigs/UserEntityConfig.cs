using api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Database.EntityConfigs
{
    public class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.Property(u => u.RowVersion);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.HasKey(u => u.UserId);
            builder.HasIndex(u => u.UserId).IsUnique().IsClustered(false).HasDatabaseName("IX_User_UserId");
            builder.HasIndex(u => u.Email).IsUnique().IsClustered(false).HasDatabaseName("IX_User_Email");

        }
    }
}
