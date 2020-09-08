using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Infrastructure.Domain;

namespace Workshop.Infrastructure
{
  public class QuizesRepository : IQuizesRepository
  {
    private readonly WorkshopContext _joContext;

    public QuizesRepository(WorkshopContext context)
    {
      _joContext = context;
    }

    public async Task<Quize> Create(Quize item)
    {
      var ret = _joContext.Quizes.Add(item);
      await _joContext.SaveChangesAsync();
      return ret.Entity;
    }

    public async Task<Quize> FindById(long id, bool includeAll)
    {
      if (includeAll)
      {
        return
           await _joContext.Quizes
             .Include(q => q.Questions)
             .ThenInclude(q => q.Answers)
             .FirstOrDefaultAsync(q => q.Id == id);
      }
      else
      {
        return
            await _joContext.Quizes.FindAsync(id);

      }
    }

    public async Task<IList<Quize>> GetAll(bool includeAll)
    {
      if (includeAll)
      {
        return
          await _joContext
          .Quizes
          .Include(q => q.Questions)
          .ToListAsync();
      }
      else
      {
        return
          await _joContext
          .Quizes
          .ToListAsync();
      }
    }

    public async Task<Quize> Update(long id, Quize item)
    {
      if (item is null)
      {
        return null;
      }

      var exist = await FindById(id, false);
      if (exist != null)
      {
        _joContext.Entry(exist).CurrentValues.SetValues(item);
        _joContext.SaveChanges();
      }

      return exist;
    }
  }
}