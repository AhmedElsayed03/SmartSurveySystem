using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.Services.Identity;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Execptions;
using Survey.Application.Models.DTOs;
using Survey.Application.Models.Identity;
using Survey.Domain.Entities;
using Survey.Infrastructure.Extensions;
using Survey.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Survey.Infrastructure.InfrastractureConstants;

namespace Survey.Infrastructure.Identity.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<SystemRole> _roleManager;
        private readonly IMemberService _memberService;
        private readonly IAdminService _adminService;
        private readonly JwtSettings _jwtSettings;


        public AuthService(UserManager<SystemUser> userManager, RoleManager<SystemRole> roleManager, IMemberService memberService, IAdminService adminService,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _memberService = memberService;
            _adminService = adminService;
            _jwtSettings = jwtSettings.Value;

        }

        #region Register For Admin
        public async Task<RegisterResponseDto> RegisterAdminAsync(RegisterAdminRequestDto request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                throw new BadRequestException(ErrorMessages.EmailExists);
            }

            //Inserting Resgister Data
            var newUser = new SystemUser
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

            };

            //Inserting Password to create the new account
            var creationResult = await _userManager.CreateAsync(newUser, request.Password);
            creationResult.ThrowIfFailed(ErrorMessages.RegistrationFailed);


            var addToRoleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
            addToRoleResult.ThrowIfFailed(ErrorMessages.AddingUserToRoleFailed);


            //Getting Roles to insert them as claims
            var userRoles = await _userManager.GetRolesAsync(newUser);


            //Determine the claims for the new user
            IEnumerable<Claim> claims = [
                       new(ClaimTypes.NameIdentifier, newUser.Id.ToString()), //ID
                       new(ClaimTypes.Email, newUser.Email), //Email
                       new("sub", newUser.UserName), //UserName

            ];

            //Adding Roles as claims
            claims = claims.Concat(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));


            //Adding Claims (initial roles + claims)
            var claimsResult = await _userManager.AddClaimsAsync(newUser, claims);
            claimsResult.ThrowIfFailed(ErrorMessages.RegistrationFailed);


            //Adding User to members table

            var newAdmin = new AdminAddDto { UserId = newUser.Id, JobTitle = request.JobTitle, Department = request.Department};
            await _adminService.AddAdminAsync(newAdmin);


            return new RegisterResponseDto(
                newUser.Id,
                newUser.UserName,
                newUser.FirstName,
                newUser.LastName,
                newUser.Email,
                userRoles);
        }
        #endregion

        #region Register For External User
        public async Task<RegisterResponseDto> RegisterMemberAsync(RegisterMemberRequestDto request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                throw new BadRequestException(ErrorMessages.EmailExists);
            }

            //Inserting Resgister Data
            var newUser = new SystemUser
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

            };

            //Inserting Password to create the new account
            var creationResult = await _userManager.CreateAsync(newUser, request.Password);
            creationResult.ThrowIfFailed(ErrorMessages.RegistrationFailed);


            var addToRoleResult = await _userManager.AddToRoleAsync(newUser, "Member");
            addToRoleResult.ThrowIfFailed(ErrorMessages.AddingUserToRoleFailed);


            //Getting Roles to insert them as claims
            var userRoles = await _userManager.GetRolesAsync(newUser);


            //Determine the claims for the new user
            IEnumerable<Claim> claims = [
                       new(ClaimTypes.NameIdentifier, newUser.Id.ToString()), //ID
                       new(ClaimTypes.Email, newUser.Email), //Email
                       new("sub", newUser.UserName), //UserName

            ];

            //Adding Roles as claims
            claims = claims.Concat(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));


            //Adding Claims (initial roles + claims)
            var claimsResult = await _userManager.AddClaimsAsync(newUser, claims);
            claimsResult.ThrowIfFailed(ErrorMessages.RegistrationFailed);


            //Adding User to members table

            var newMember = new MemberAddDto { UserId = newUser.Id, Age = request.Age, Location = request.Location };
            await _memberService.AddMemberAsync(newMember);


            return new RegisterResponseDto(
                newUser.Id,
                newUser.UserName,
                newUser.FirstName,
                newUser.LastName,
                newUser.Email,
                userRoles);
        }


        #endregion


        #region Login
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {

            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser is null)
            {
                throw new UnauthorizedException(ErrorMessages.IncorrectCredentials);
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);
            if (!isCorrect)
            {
                var attempts = _userManager.AccessFailedAsync(existingUser); //Faild Accessing Attempts
                throw new UnauthorizedException(ErrorMessages.IncorrectCredentials);
            }

            var token = await GenerateJwtToken(existingUser);

            var userRoles = await _userManager.GetRolesAsync(existingUser);
            return new AuthResponseDto(token.Token,
                token.Expiry,
                existingUser.Id,
                existingUser.UserName!,
                //existingUser.Email!,
                //existingUser.FirstName,
                //existingUser.LastName!,
                //true,//existingUser.EmailConfirmed,
                userRoles);
        }



        private async Task<TokenDto> GenerateJwtToken(SystemUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            var keyInBytes = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var expiryDate = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes);

            var jwt = new JwtSecurityToken(claims: claims,
                expires: expiryDate,
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);


            //Fetching user id from token
            var tokenRead = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
            string UserID = tokenRead.Subject;

            return new TokenDto { Token = tokenString, Expiry = jwt.ValidTo, UserId = UserID };
        }
        #endregion


        #region Add Role
        public async Task AddRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                throw new BadRequestException(ErrorMessages.RoleExists);
            }
            await _roleManager.CreateAsync(new SystemRole(roleName));
        }
        #endregion


        #region Get Roles
        public async Task<List<RoleDto>> GetRolesAsync()
        {
            return await _roleManager.Roles
                .Select(r => new RoleDto(r.Id, r.Name!))
                .ToListAsync();
        }
        #endregion


        #region Get User (UserNames) In Role
        public async Task<List<string>> GetUsersInRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                throw new NotFoundException(ErrorMessages.RoleNotFound);
            }
            var users = await _userManager.GetUsersInRoleAsync(role.Name!);
            return users
                .Select(u => u.UserName!)
                .ToList();
        }
        #endregion


        #region Add User To Role
        public async Task AddUserToRoleAsync(string roleId, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new NotFoundException(ErrorMessages.UserNotFound);
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                throw new NotFoundException(ErrorMessages.RoleNotFound);
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name!);
            addToRoleResult.ThrowIfFailed(ErrorMessages.AddingUserToRoleFailed);
        }

        #endregion


        #region Remove User From Role

        public async Task RemoveUserFromRoleAsync(string roleId, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                throw new NotFoundException(ErrorMessages.UserNotFound);
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                throw new NotFoundException(ErrorMessages.RoleNotFound);
            }

            var removeFromRoleResult = await _userManager.RemoveFromRoleAsync(user, role.Name!);
            removeFromRoleResult.ThrowIfFailed(ErrorMessages.RemovingFromRoleFailed);
        }
        #endregion
    }
}