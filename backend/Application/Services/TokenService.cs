using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RpgApi.Application.Services.Interfaces;
using RpgApi.Domain.Entities;

namespace RpgApi.Application.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
        };
        
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
            ?? string.Empty;
        var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
            ?? string.Empty;
        var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") 
            ??string.Empty;
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddHours(8),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}