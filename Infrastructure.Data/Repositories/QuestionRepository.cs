using Application.Repositories.Interfaces;
using Domain.Entities;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    internal class QuestionRepository(AppDbContext dbContext) : RepositoryBase<Question>(dbContext), IQuestionRepository
    {

        private readonly AppDbContext _appDbContext = dbContext;

        public override Task<Question?> GetByIdAsync(Guid id, CancellationToken? token)
        {
            return _appDbContext.Questions.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
