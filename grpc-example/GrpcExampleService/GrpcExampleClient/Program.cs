using Grpc.Net.Client;
using GrpcExampleService;
using System;

namespace GrpcExampleClient
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      // The port number(5001) must match the port of the gRPC server.
      var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new QuizeDefinition.QuizeDefinitionClient(channel);
      var request = new QuizeIdMessage { Id = 1 };
      var reply = client.GetQuizeByID(request);
      //var client = new CreditRatingCheck.CreditRatingCheckClient(channel);
      //var creditRequest = new CreditRequest { CustomerId = "id0201", Credit = 7000 };
      //var reply = await client.CheckCreditRequestAsync(creditRequest);

      Console.WriteLine($"{reply.Id}, {reply.Name}, {reply.Description}");
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
