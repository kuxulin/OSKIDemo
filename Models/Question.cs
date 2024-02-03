namespace OSKIDemo.Models;

public class Question
{
    public Guid Id { get; set; }
    public Guid TestId { get; set; }
    public string Text { get; set; }
    public ICollection<Answer> Answers { get; set; }
}
