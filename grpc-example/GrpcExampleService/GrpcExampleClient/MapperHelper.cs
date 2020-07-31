
using AutoMapper;
using Google.Protobuf.Collections;
using System.Collections.Generic;

namespace GrpcExampleClient
{
  public class EnumerableToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IEnumerable<TITemSource>, RepeatedField<TITemDest>>
  {
    public RepeatedField<TITemDest> Convert(IEnumerable<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
    {
      destination = destination ?? new RepeatedField<TITemDest>();
      foreach (var item in source)
      {
        destination.Add(context.Mapper.Map<TITemDest>(item));
      }
      return destination;
    }
  }

  public class RepeatedFieldToListTypeConverter<TITemSource, TITemDest>
    : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
  {
    public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
    {
      destination = destination ?? new List<TITemDest>();
      foreach (var item in source)
      {
        destination.Add(context.Mapper.Map<TITemDest>(item));
      }
      return destination;
    }
  }
}
