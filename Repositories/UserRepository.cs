using Microsoft.AspNetCore.Identity;
using OSKIDemo.Interfaces;
using OSKIDemo.Models;

namespace OSKIDemo.Repositories;

public class UserRepository :IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ApplicationUser> GetUserAsync(Guid userId)
    {
        return await _userManager.FindByIdAsync(userId.ToString());
    }
}
