using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OSKIDemo.Interfaces;
using OSKIDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OSKIDemo.Services;

public class TokenService :ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _config = configuration;
        _userManager = userManager;
    }

    public JwtSecurityToken CreateToken(ApplicationUser user)
    {
        var authClaims = new List<Claim>
        {
            new Claim("userId",user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}
