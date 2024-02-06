using OSKIDemo.Models;

namespace OSKIDemo.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser> GetUserAsync(Guid userId);
}
