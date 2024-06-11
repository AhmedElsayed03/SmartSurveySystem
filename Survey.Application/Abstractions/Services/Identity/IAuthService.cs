using Survey.Application.Models.DTOs;
using Survey.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services.Identity
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterMemberAsync(RegisterMemberRequestDto request);
        Task<RegisterResponseDto> RegisterAdminAsync(RegisterAdminRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task AddRoleAsync(string roleName);
        Task<List<RoleDto>> GetRolesAsync();
        Task<List<string>> GetUsersInRoleAsync(string roleId);
        Task AddUserToRoleAsync(string roleId, string userId);
        Task RemoveUserFromRoleAsync(string roleId, string userId);
        
    }
}
