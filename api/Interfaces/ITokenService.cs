using api.Database.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace api.Interfaces
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateJwtToken(UserEntity user);
     
    }
}
