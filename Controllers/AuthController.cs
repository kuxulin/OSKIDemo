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
    [Route("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        ApplicationUser possibleUser = await _userManager.FindByNameAsync(model.Login);

        if (possibleUser != null)
            return BadRequest("User already exists!");

        ApplicationUser user = new()
        {
            UserName = model.Login,
        };

        IdentityResult result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return StatusCode(500,"User creation failed!" );

        return Ok("User created successfully!");
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

        return Unauthorized();
    }

    [HttpGet]
    [Route("check-username-unique")]
    public async Task<IActionResult> CheckLoginUnique(string username)
    {

        var user = await _userManager.FindByNameAsync(username);
        if (user != null)
        {
            return BadRequest("This username is not unique!");
        }

        return Ok("This username is unique");
    }
}