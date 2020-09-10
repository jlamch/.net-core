using System.Collections.Generic;

namespace Infrastructure.Data
{
  public class Quize
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }
  }
}
