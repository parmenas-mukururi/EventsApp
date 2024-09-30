using api.Database.Entities;
using api.Database.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRolesEntity> UserRoles { get; set; }
        public DbSet<EventEntity> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new EventEntityConfig());   
        }
    }
}
