using api.DTOs.Requests;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        { 
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequestDTO request) 
        {
            if (!ModelState.IsValid)
            {
                return ApiModelErrorResponseHelper.CreateBadRequestResponse(ModelState);
            }
            var results = await _authService.RegisterUser(request);
            if(results.Success)
            {
                return StatusCode(201, results);
            }
            return BadRequest(results);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return ApiModelErrorResponseHelper.CreateBadRequestResponse(ModelState);
            }
            var results = await _authService.Login(request);
            if(results.Success)
            {
                return Ok(results);
            }
            return BadRequest(results);
        }
    }
}
