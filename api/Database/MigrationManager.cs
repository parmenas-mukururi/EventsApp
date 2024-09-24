using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public static class MigrationManager
    {

        public static async Task MigrateDatabase(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                using var appContext = services.GetRequiredService<AppDbContext>();
                try
                {
                    await appContext.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError($"Database migrations failed:{ex.InnerException} - {ex.Message} - {ex.StackTrace}");
                    throw;
                }

                var roleManager = services.GetRequiredService<IRoleService>();

                await SeedDataManager.SeedRoles(roleManager);

            }
        }
    }
}
