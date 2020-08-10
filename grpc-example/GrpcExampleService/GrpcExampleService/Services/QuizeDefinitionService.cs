using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcExampleService
{
  public class QuizeDefinitionService : QuizeDefinition.QuizeDefinitionBase
  {
    private readonly ILogger<QuizeDefinitionService> _logger;
    public QuizeDefinitionService(ILogger<QuizeDefinitionService> logger)
    {
      _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = "Hello " + request.Name
      });
    }

    public override Task<QuizeIdMessage> CreateQuize(
      QuizeMessage request,
      ServerCallContext context)
    {
      //Create  quize
      var result = new QuizeIdMessage { Id = 100 };
      return Task.FromResult(result);
    }

    public override Task<QuizeMessage> GetQuizeByID(
      QuizeIdMessage request,
      ServerCallContext context)
    {
      var result = new QuizeMessage
      {
        Id = 19,
        Name = "Bla bla quize",
        Description = "some more bla bla ",
        QuestionList =
        {
          new QuestionMessage { Id=21, Text="question1"},
          new QuestionMessage {
            Id=23,
            Text="question3",
            Answers={
              {true,"this is good" },
              { false, "this is not so good"}
            }
          },
        }
      };
      return Task.FromResult(result);
    }

    public override async Task GetQuizeList(
      QuizeIdMessage request,
      IServerStreamWriter<QuizeMessage> responseStream,
      ServerCallContext context)
    {
      var result = new List<QuizeMessage>() {
        new QuizeMessage
        {
          Id = 19,
          Name = "Bla bla quize",
          Description = "some more bla bla ",
          QuestionList =
          {
            new QuestionMessage { Id=21, Text="question1"},
            new QuestionMessage {
              Id=23,
              Text="question3",
              Answers={
                {true,"this is good" },
                { false, "this is not so good"}
              }
            },
          }
        },
        new QuizeMessage
        {
          Id = 29,
          Name = "Bla bla quize",
          Description = "some more bla bla ",
          QuestionList =
          {
            new QuestionMessage { Id=25, Text="question2"},
            new QuestionMessage {
              Id=24,
              Text="question4",
              Answers={
                {true,"this is good" },
                { false, "this is not so good"}
              }
            },
          }
        },
        new QuizeMessage
        {
          Id = 39,
          Name = "Bla bla quize",
          Description = "some more bla bla ",
          QuestionList =
          {
            new QuestionMessage { Id=26, Text="question1"},
            new QuestionMessage {
              Id=27,
              Text="question3",
              Answers={
                {true,"this is good" },
                { false, "this is not so good"}
              }
            },
          }
        }
      };

      foreach (var item in result)
      {
        await responseStream.WriteAsync(item);
      }
    }
  }
}
