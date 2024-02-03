namespace OSKIDemo.Models;

public class UserTest
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public Guid TestId { get; set; }
    public Test Test { get; set; }
    public int Mark {  get; set; }
}
