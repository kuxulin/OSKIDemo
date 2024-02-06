using Microsoft.AspNetCore.Identity;

namespace OSKIDemo.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserTest> UserTests { get; set; }
}
