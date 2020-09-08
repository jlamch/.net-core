namespace GraphQlExample.Data
{
  public class Answer
  {
    public long Id { get; set; }
    public Question Question { get; set; }
    public string Text { get; set; }
    public bool? IsCorrect { get; set; }
  }
}
