using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.Infrastructure.Domain
{
  public interface IAnswerRepository
  {
    Task<ICollection<Answer>> GetAll();

    Task<Answer> FindById(long id);

    Task<IList<Answer>> FindByQuestionId(long questionId);

    Task<Answer> Create(Answer item, long questionId);

    Task<Answer> Update(Answer item, long id);
  }
}
