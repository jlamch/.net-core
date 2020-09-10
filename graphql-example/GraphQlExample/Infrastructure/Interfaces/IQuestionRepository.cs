using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.Infrastructure.Domain
{
  public interface IQuestionRepository
  {
    Task<ICollection<Question>> GetAll(bool includeAll = true);

    Task<Question> FindById(long id);

    Task<IList<Question>> FindByQuizeId(long quizeId, bool includeAll = true);

    Task<Question> Create(Question item, long quizeId);

    Task<Question> Update(Question item, long id);
  }
}
