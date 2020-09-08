using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Infrastructure;
using Workshop.Infrastructure.Domain;

namespace Workshop.Infrastructure
{
  public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
  {
    private readonly WorkshopContext _joContext;

    public QuestionRepository(WorkshopContext context) : base(context)
    {
      _joContext = context;
    }

    public async Task<Question> Create(Question item, long quizeId)
    {
      item.Quize = _joContext.Quizes.Find(quizeId);
      return await base.AddAsyn(item);
    }

    public async Task<Question> FindById(long questionId)
    {
      return await base.FindAsync(q => q.Id == questionId);
    }

    public async Task<Question> Update(Question item, long id)
    {
      return await base.UpdateAsync(item, id);
    }

    public async Task<IList<Question>> FindByQuizeId(long quizeId, bool includeAll)
    {
      if (includeAll)
      {
        return
          await _joContext
          .Questions
          .Include(q => q.Quize)
          .Include(q => q.Answers)
          .Where(q => q.Quize.Id == quizeId)
          .ToListAsync();
      }
      else
      {
        return
          await _joContext
          .Questions
          .Where(q => q.Quize.Id == quizeId)
          .ToListAsync();
      }
    }

    public async Task<ICollection<Question>> GetAll(bool includeAll)
    {
      if (includeAll)
      {
        return
          await _joContext
          .Questions
          .Include(q => q.Quize)
          .Include(q => q.Answers)
          .ToListAsync();
      }
      else
      {
        return
          await _joContext
          .Questions
          .ToListAsync();
      }
    }
  }
}
