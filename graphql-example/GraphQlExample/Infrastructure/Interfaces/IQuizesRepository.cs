using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.Infrastructure.Domain
{
  public interface IQuizesRepository
  {
    Task<IList<Quize>> GetAll(bool includeAll = true);
    Task<Quize> FindById(long id, bool includeAll = true);
    Task<Quize> Create(Quize q);
    Task<Quize> Update(long id, Quize q);
  }
}