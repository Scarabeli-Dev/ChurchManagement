using Authentication.API.Models;
using Authentication.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Services;

public class TokenService : ITokenService
{
  public async Task<string> CreateToken(User user, List<string> roles, string key, string issuer, string audience)
  {
    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        };

    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

    var credentials = new SigningCredentials(securityKey,
                                         SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(issuer: issuer,
                                     audience: audience,
                                     claims: claims,
                                     expires: DateTime.Now.AddDays(5),
                                     signingCredentials: credentials);

    var tokenHandler = new JwtSecurityTokenHandler();

    var stringToken = tokenHandler.WriteToken(token);

    return stringToken;
  }
}