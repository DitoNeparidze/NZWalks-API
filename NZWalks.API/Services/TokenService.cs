using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateJwtToken(string userId, string email, List<string> roles)
    {
        var claims = new List<Claim>
       {
           new Claim(ClaimTypes.NameIdentifier, userId),
           new Claim(ClaimTypes.Email, email)
       };

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var keyValue = _configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("Jwt key is missing");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
}
