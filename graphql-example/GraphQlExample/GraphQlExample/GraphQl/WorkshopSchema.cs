using GraphQL.Types;
using System;

namespace GraphQlExample.GraphQl
{
  public class WorkshopSchema : Schema
  {
    public WorkshopSchema(IServiceProvider provider) : base(provider)
    {
      Query = provider.GetService(typeof(JohootQuery)) as JohootQuery;

      Mutation = provider.GetService(typeof(CarvedRockMutation)) as CarvedRockMutation;
    }
  }
}
