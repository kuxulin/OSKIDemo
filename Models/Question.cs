namespace OSKIDemo.Models;

public class Question :BaseEntity
{
    public Guid TestId { get; set; }
    public string Text { get; set; }
    public ICollection<Answer> Answers { get; set; }
}