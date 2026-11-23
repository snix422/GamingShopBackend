using FootballShopBackend.Application.Common;
using FootballShopBackend.Application.Contracts.Infrastracture;
using FootballShopBackend.Application.Features.Auth.Commands.Login;
using FootballShopBackend.Application.Features.Auth.Commands.Register;
using FootballShopBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Infrastracture.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<Result<string>> RegisterAsync(RegisterUserVM dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if(existingUser != null)
            {
                return Result<string>.Failure("Email jest zajęty");
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                var error = string.Join("\n", result.Errors.Select(e => e.Description));
                return Result<string>.Failure($"Rejestracja nie powiodła się: {error}");
            }

            string roleToAssign = "User";

            if(!await _roleManager.RoleExistsAsync(roleToAssign))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleToAssign));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, roleToAssign);

            if(!roleResult.Succeeded)
            {
                var error = string.Join("\n", roleResult.Errors.Select(e => e.Description));
                return Result<string>.Failure($"Przypisanie roli nie powiodło się: {error}");
            }

            return Result<string>.Success("Rejestracja zakończona sukcesem");
        }

        public async Task<Result<string>> LoginAsync(LoginUserVM dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return Result<string>.Failure("Nieprawidłowy email lub hasło");
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                return Result<string>.Failure("Nieprawidłowy email lub hasło");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles);
            return Result<string>.Success(token);
        }

        private string GenerateJwtToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}   
