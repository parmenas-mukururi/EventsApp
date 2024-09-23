using api.Database.Entities;
using api.DTOs.Requests;

namespace api.Interfaces
{
    public interface IRoleService
    {
        Task<GetRolesResponseDTO> AddRole(string roleName);
        Task<GetRolesResponseDTO> AssignRoleToUser(UserEntity user, string roleName);
        Task<bool> RoleExists(string roleName);
        Task<List<string>> GetRoles(Guid userId);
    }
}
