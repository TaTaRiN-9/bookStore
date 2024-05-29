using System.IdentityModel.Tokens.Jwt;
using TestWebApi.Core.Models;
using System.Security.Claims;
using TestWebApi.Core.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Application.Services
{
    // сервис для генерации токена
    public class JwtServices : IJwtServices
    {
        public string Generate(User user)
        {
            // для создания хранения данных
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };

            // создаем сам токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
