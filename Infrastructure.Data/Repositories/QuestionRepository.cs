using Application.Repositories.Interfaces;
using Domain.Entities;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class QuestionRepository(AppDbContext dbContext) : RepositoryBase<Question>(dbContext), IQuestionRepository
    {

        private readonly AppDbContext _appDbContext = dbContext;

        public override async Task<Question?> GetByIdAsync(Guid id, CancellationToken? token)
        {
            return await _appDbContext.Questions.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsByFormId(Guid formId)
        {
            return await _appDbContext.Questions.Include(x => x.Options).Where(x => x.FormId  == formId).ToListAsync();
        }
    }
}
