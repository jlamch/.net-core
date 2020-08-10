using AutoMapper;
using Google.Protobuf.Collections;
using Grpc.Net.Client;
using GrpcExampleService;
using System;
using System.Collections.Generic;

namespace GrpcExampleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      var conf = new MapperConfiguration(ce =>
      {//https://dotnetfiddle.net/RPWSUd
        ce.CreateMap<Quize, QuizeMessage>().ReverseMap();
        ce.CreateMap<Question, QuestionMessage>().ReverseMap();
        ce.CreateMap(typeof(IEnumerable<>), typeof(RepeatedField<>)).ConvertUsing(typeof(EnumerableToRepeatedFieldTypeConverter<,>));
        ce.CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));

        ce.ForAllPropertyMaps(
          map => map.DestinationType.IsGenericType && map.DestinationType.GetGenericTypeDefinition() == typeof(RepeatedField<>),
          (map, options) => options.UseDestinationValue());
        //.ForAllOtherMembers(
        //options => options.Condition((src, dest, srcValue) => srcValue != null));
      });
      var mapper = new Mapper(conf);

      // The port number(5001) must match the port of the gRPC server.
      var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new QuizeDefinition.QuizeDefinitionClient(channel);
      var request = new QuizeIdMessage { Id = 1 };
      QuizeMessage reply = client.GetQuizeByID(request);

      var mapped = mapper.Map<Quize>(reply);
      var questions = mapper.Map<List<Question>>(reply.QuestionList);
      mapped.Questions = questions;


      Console.WriteLine($"{reply.Id}, {reply.Name}, {reply.Description}, {reply.QuestionList?.Count}");
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
