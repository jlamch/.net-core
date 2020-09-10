using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Workshop.Infrastructure
{
  public class WorkshopContext : DbContext
  {
    public WorkshopContext(DbContextOptions<WorkshopContext> options) : base(options)
    {
    }

    public DbSet<Quize> Quizes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
