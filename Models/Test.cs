namespace OSKIDemo.Models;

public class Test
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimeSpan CompletionTime { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<UserTest> UserTests { get; set; }
}