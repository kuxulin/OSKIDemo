using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSKIDemo.Interfaces;
using OSKIDemo.Models;
using OSKIDemo.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;

namespace OSKIDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = await _userManager
            .Users
            .FirstOrDefaultAsync(x => x.UserName == model.Login);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = _tokenService.CreateToken(user);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        return Unauthorized("There were some troubles with provided login or password");
    }
}