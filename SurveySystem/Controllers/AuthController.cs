using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Abstractions.Services.Identity;
using Survey.Application.Models.DTOs;
using Survey.Application.Models.Identity;

namespace SurveySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register-user")]
        public async Task<Ok<RegisterResponseDto>> RegisterMemberAsync(RegisterMemberRequestDto request)
        {
            var response = await _authService.RegisterAsync(request);
            return TypedResults.Ok(response);
        }


        [HttpPost("login")]
        public async Task<Ok<AuthResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);
            return TypedResults.Ok(response);
        }


        [HttpPost("add-role")]
        public async Task<NoContent> CreateRoleAsync(string roleName)
        {
            await _authService.AddRoleAsync(roleName);
            return TypedResults.NoContent();
        }


        [HttpGet("roles")]
        public async Task<Ok<List<RoleDto>>> GetRolesAsync()
        {
            var response = await _authService.GetRolesAsync();
            return TypedResults.Ok(response);

        }


        [HttpGet("users-in-role/{roleId}")]
        public async Task<Ok<List<string>>> GetUsersInRoleAsync(string roleId)
        {
            var response = await _authService.GetUsersInRoleAsync(roleId);
            return TypedResults.Ok(response);
        }


        [HttpPost("addRole/{roleId}/to/{userId}")]
        public async Task<NoContent> AddUserToRoleAsync(string roleId, string userId)
        {
            await _authService.AddUserToRoleAsync(roleId, userId);
            return TypedResults.NoContent();
        }


        [HttpDelete("removeRole/{roleId}/from/{userId}")]
        public async Task<NoContent> RemoveUserFromRoleAsync(string roleId, string userId)
        {
            await _authService.RemoveUserFromRoleAsync(roleId, userId);
            return TypedResults.NoContent();
        }

    }
}
