using api.DTOs.Requests;
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
        public static async Task SeedAdminUser(IAuthService authService, IRoleService roleService)
        {
            if (!await roleService.RoleExists("Admin"))
            {
                await roleService.AddRole("Admin");
            }

            var adminUser = new RegisterUserRequestDTO
            {
                Email = "admin@example.com",
                Password = "Admin@123", 
                FirstName = "Admin",
                LastName = "User"
            };

            var user = await authService.GetUserByEmail(adminUser.Email);
            if (user == null)
            {
                var response = await authService.RegisterUser(adminUser);

                if (response.Success)
                {
                    var newUser = await authService.GetUserByEmail(adminUser.Email);

                    if (newUser != null)
                    {
                        await roleService.AssignRoleToUser(newUser, "Admin");
                    }
                    
                }
            }
        }
    }
}
