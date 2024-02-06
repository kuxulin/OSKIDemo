namespace OSKIDemo.Models;

public class UserTest
{
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public Guid TestId { get; set; }
    public Test Test { get; set; }
    public int Mark {  get; set; }
    public bool IsCompleted { get; set; }
}
