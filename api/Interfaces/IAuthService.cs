using api.Database.Entities;
using api.DTOs.Requests;
using api.DTOs.Responses;

namespace api.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO requestDTO);
        Task<UserEntity> GetUserByEmail(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO);
    }
}
