﻿namespace OSKIDemo.Models;

public class Answer
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public string Text { get; set; }
    public bool IsRight { get; set; }
}
