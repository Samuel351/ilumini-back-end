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
    public class FormRepository(AppDbContext dbContext) : RepositoryBase<Form>(dbContext), IFormRepository
    {
        private readonly AppDbContext _appDbContext = dbContext;

        public override async Task<Form?> GetByIdAsync(Guid id, CancellationToken? token)
        {
            return await _appDbContext.Forms.Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
