using OSKIDemo.Models;
using System.IdentityModel.Tokens.Jwt;

namespace OSKIDemo.Interfaces;

public interface ITokenService
{
    JwtSecurityToken CreateToken(ApplicationUser user);
}
