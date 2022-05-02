using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.Application.Models.Jwt;
using DDD.UserAccess.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Infrastructure.Identity
{
    public class JwtService : IJwtServices
    {
        private readonly JwtModel _jwtModel;
        private readonly UserManager<User> _userManager;
        public JwtService(IOptionsSnapshot<JwtModel> settings, UserManager<User> userManager)
        {
            _jwtModel = settings.Value;
            _userManager = userManager;
        }
        public string Generate(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_jwtModel.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(_jwtModel.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = GetClaims(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "Test",
                Audience = "Test",
                IssuedAt = DateTime.UtcNow, 
                Expires = DateTime.UtcNow.AddMinutes(1000),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims) 
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(descriptor);

            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }

        public List<Claim> GetClaims(User user)
        { 
            var list = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (!string.IsNullOrEmpty(user.Email))
            {
                list.Add(new Claim(ClaimTypes.Email, user.Email));
            }

            var roles = _userManager.GetRolesAsync(user).Result; 
            if (roles is not null && roles.Any())
            {
                foreach (var role in roles)
                {
                    list.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return list;
        }
    }
}
