using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsByFormId(Guid formId);
    }
}
