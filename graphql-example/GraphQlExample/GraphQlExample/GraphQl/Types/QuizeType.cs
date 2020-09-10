using GraphQL.Types;
using Infrastructure.Data;

namespace GraphQlExample.GraphQl.Types
{
  public class QuizeType : ObjectGraphType<Quize>
  {
    public QuizeType(GraphQL.DataLoader.IDataLoaderContextAccessor dataLoaderAccessor)
    {
      Field(t => t.Id);
      Field(t => t.Name).Description("The name of the quize");
      Field(t => t.Description);

      //Field<ListGraphType<QuestionType>>(
      //         "questions",
      //         resolve: context =>
      //         {
      //           var loader =
      //                dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Question>(
      //                    "GetReviewsByProductId", reviewRepository.GetForProducts);
      //           return loader.LoadAsync(context.Source.Id);
      //         });
    }
  }
}
