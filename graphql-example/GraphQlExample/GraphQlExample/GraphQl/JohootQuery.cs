using GraphQL.Types;
using GraphQlExample.GraphQl.Types;
using Workshop.Infrastructure.Domain;

namespace GraphQlExample.GraphQl
{
  public class JohootQuery : ObjectGraphType
  {
    public JohootQuery(IQuizesRepository repository)
    {
      Field<ListGraphType<QuizeType>>(
          "quizes",
          resolve: context => repository.GetAll()
      );
      Field<ListGraphType<QuestionType>>(
        "questions",
        resolve: context => repository.GetAll()
        );
    }
  }
}
