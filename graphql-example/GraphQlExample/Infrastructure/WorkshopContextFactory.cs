

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Workshop.Infrastructure
{
  public class WorkshopContextFactory : IDesignTimeDbContextFactory<WorkshopContext>
  {
    private const string ConnectionStringName = "DefaultDbConnection";
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    public WorkshopContext CreateDbContext(string[] args)
    {
      return Create(
       Directory.GetCurrentDirectory(),
       Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
    }

    protected WorkshopContext CreateNewInstance(DbContextOptions<WorkshopContext> options)
    {
      return new WorkshopContext(options);
    }

    private WorkshopContext Create(string basePath, string environmentName)
    {
      var configuration = new ConfigurationBuilder()
       .SetBasePath(basePath)
       .AddJsonFile("appsettings.json")
       .AddJsonFile($"appsettings.Local.json", optional: true)
       .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
       .AddEnvironmentVariables()
       .Build();

      var connectionString = configuration.GetConnectionString(ConnectionStringName);

      return Create(connectionString);
    }

    private WorkshopContext Create(string connectionString)
    {
      if (string.IsNullOrEmpty(connectionString))
      {
        throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
      }

      Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

      var optionsBuilder = new DbContextOptionsBuilder<WorkshopContext>();

      optionsBuilder.UseSqlServer(connectionString);

      return CreateNewInstance(optionsBuilder.Options);
    }
  }


}

