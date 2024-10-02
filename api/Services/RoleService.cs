using api.Database;
using api.Database.Entities;
using api.DTOs.Requests;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _dbContext;
        public RoleService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRolesResponseDTO> AddRole(string roleName)
        {
            try
            {
                RoleEntity role = new RoleEntity()
                { RoleName = roleName };

                if (!await this.RoleExists(roleName))
                {
                    _dbContext.Roles.Add(role);
                    await _dbContext.SaveChangesAsync();

                    return new GetRolesResponseDTO()
                    {
                        Success = true,
                        Message = "Role added successfully"
                    };
                }
                return new GetRolesResponseDTO()
                {
                    Success = false,
                    Message = "Role already exists"
                };
            }
            catch (Exception ex)
            {
                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new GetRolesResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Role registration failed. Please try again later",
                    Success = false
                };
            }
        }

        public async Task<GetRolesResponseDTO> AssignRoleToUser(UserEntity user, string roleName)
        {
            try
            {
                RoleEntity role = await _dbContext.Roles.SingleOrDefaultAsync(x => x.RoleName == roleName);
                if (role == null)
                {
                    throw new ArgumentNullException(nameof(role));
                }

                var userRoleExists = await _dbContext.UserRoles.AnyAsync(ur => ur.UserId == user.UserId && ur.RoleId == role.RoleId);
                if (userRoleExists)
                {
                    return new GetRolesResponseDTO
                    {
                        Success = false,
                        Message = "User already has this role assigned."
                    };
                }

                _dbContext.UserRoles.Add(new UserRolesEntity
                {
                    UserId = user.UserId,
                    RoleId = role.RoleId
                }
                    );
                await _dbContext.SaveChangesAsync();

                return new GetRolesResponseDTO()
                {
                    Success = true,
                    Message = "Role assigned successfully to user"
                };
            }
            catch (Exception ex)
            {
                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new GetRolesResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Role assignment failed. Please try again later",
                    Success = false
                };
            }
        }

        public async Task<List<string>> GetRoles(Guid userId)
        {
            var roles = await _dbContext.UserRoles.Where(u => u.UserId == userId).Select(r => r.Role.RoleName).ToListAsync();
            return roles;
        }

        public async Task<bool> RoleExists(string roleName)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            return role != null;
        }
    }
}
