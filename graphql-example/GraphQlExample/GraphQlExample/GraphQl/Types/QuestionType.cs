using GraphQL.Types;
using Infrastructure.Data;

namespace GraphQlExample.GraphQl.Types
{
  public class QuestionType : ObjectGraphType<Question>
  {
    public QuestionType()
    {
      Field(t => t.Id);
      Field(t => t.Points).Description("How many points is question worth");
      Field(t => t.Text);
      Field(t => t.TimeLimitSeconds);
      Field(t => t.IsOpenQuestion);
      Field(t => t.HasCorrectAnswer);
    }
  }
}
