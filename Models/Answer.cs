using System.Text.Json.Serialization;

namespace OSKIDemo.Models;

public class Answer : BaseEntity
{
    public Guid QuestionId { get; set; }
    [JsonIgnore]
    public Question Question { get; set; }
    public string Text { get; set; }
    public bool IsRight { get; set; }
}
