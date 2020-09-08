using System.Collections.Generic;

namespace Infrastructure.Data
{
  public class Question
  {
    public long Id { get; set; }
    public Quize Quize { get; set; }

    public int TimeLimitSeconds { get; set; }
    public string Text { get; set; }
    public int Points { get; set; }
    public List<Answer> Answers { get; set; }

    public bool HasCorrectAnswer { get; set; }
    public bool IsOpenQuestion { get; set; }

    public string ImageUri { get; set; }
  }
}
