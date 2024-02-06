namespace OSKIDemo.Models.ViewModels;

public class TestSpecificViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
