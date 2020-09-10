using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQlExample.GraphQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workshop.Infrastructure;
using Workshop.Infrastructure.Domain;

namespace GraphQlExample
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<WorkshopContext>(cfg =>
      {
        cfg.UseSqlServer(Configuration.GetConnectionString("DefaultDbConnection"));
      });

      services.AddScoped<IQuestionRepository, QuestionRepository>();
      services.AddScoped<IQuizesRepository, QuizesRepository>();
      services.AddScoped<IAnswerRepository, AnswerRepository>();

      services.AddSingleton<WorkshopSchema>();
      services.AddGraphQL(options =>
              {
                options.ExposeExceptions = false;
                options.EnableMetrics = true;
              })
              .AddGraphTypes(ServiceLifetime.Scoped);



    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseGraphQL<WorkshopSchema>();
      app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
    }
  }
}
