namespace OSKIDemo.Models;

public class Test :BaseEntity
{
    public string Name { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<UserTest> UserTests { get; set; }
}