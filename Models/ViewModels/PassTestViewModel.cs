namespace OSKIDemo.Models.ViewModels;

public class PassTestViewModel
{
    public Guid TestId { get; set; }
    public Guid UserId { get; set; }
    public IEnumerable<Guid> AnswerIds { get; set; }
}
