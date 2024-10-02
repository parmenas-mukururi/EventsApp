using api.Database;
using api.Database.Entities;
using api.DTOs.Requests;
using api.DTOs.Responses;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly IRoleService _roleService;
        public AuthService(AppDbContext dbContext, IPasswordService passwordService, ITokenService tokenService, JwtSecurityTokenHandler jwtSecurityTokenHandler, IRoleService roleService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _roleService = roleService;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            try
            {
                UserEntity user = await this.GetUserByEmail(requestDTO.Email);
                if (user == null)
                {
                    return new LoginResponseDTO()
                    {
                        Success = false,
                        Message = "Email not found",
                        IsAuthenticated = false,
                    };
                }

                if (!_passwordService.VerifyHashedPassword(requestDTO.Password, user.Password))
                {
                    return new LoginResponseDTO()
                    {
                        Success = false,
                        Message = "Incorrect email or password",
                        IsAuthenticated = false,
                    };
                }

                JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateJwtToken(user);


                return new LoginResponseDTO()
                {
                    Success = true,
                    Message = "Login successful",
                    IsAuthenticated = true,
                    Token = _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
            }
            catch (Exception ex)
            {
                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new LoginResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Login failed. Please try again later",
                    Success = false,
                    IsAuthenticated = false,
                };
            }
        }

        public async Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO requestDTO)
        {
            try
            {
                var user = await this.GetUserByEmail(requestDTO.Email);

                if (user == null)
                {
                    var newUser = new UserEntity
                    {
                        FirstName = requestDTO.FirstName,
                        LastName = requestDTO.LastName,
                        Email = requestDTO.Email,
                        Password = _passwordService.HashPassword(requestDTO.Password),
                    };


                    _dbContext.Users.Add(newUser);
                    await _dbContext.SaveChangesAsync();


                    await _roleService.AssignRoleToUser(newUser, "Admin");


                    return new RegisterUserResponseDTO
                    {
                        Success = true,
                        Message = "User registered successfully"
                    };
                }
                return new RegisterUserResponseDTO
                {
                    Success = false,
                    Message = "User already exists with this email"
                };
            }
            catch (Exception ex)
            {
                List<string> errorMessages = ExceptionHelper.GetErrorMessages(ex);

                return new RegisterUserResponseDTO()
                {
                    Errors = errorMessages,
                    Message = "Registration failed. Please try again later",
                    Success = false
                };
            }
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
