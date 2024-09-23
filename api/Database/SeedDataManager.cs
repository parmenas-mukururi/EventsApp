using api.Interfaces;

namespace api.Database
{
    public static class SeedDataManager
    {
        public static async Task SeedRoles(IRoleService roleService)
        {
            var roles = new[]
            {
                "Admin",
                "User"
            };
            foreach (var role in roles)
            {
                if (!await roleService.RoleExists(role))
                {
                    await roleService.AddRole(role);
                }

            }
        }
    }
}
