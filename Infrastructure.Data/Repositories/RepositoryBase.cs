using Application.Enums;
using Application.Models;
using Application.Repositories;
using Domain.Entities;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Data.Repositories
{
    public class RepositoryBase<T>(AppDbContext dbContext) : IRepositoryBase<T> where T : EntityBase
    {
        private readonly AppDbContext _appDbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();
        public virtual async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> CreateAllAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }


        public virtual async Task DeleteAsync(T entity)
        {
            entity.Deleted = true;
            entity.LastUpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }



        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken? token)
        {
            if (token.HasValue)
                return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, token.Value);
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity.LastUpdatedAt = DateTime.UtcNow;

            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ITransaction> BeginTransaction()
        {
            IDbContextTransaction dbContextTransaction = await _appDbContext.Database.BeginTransactionAsync();
            return new Transaction(dbContextTransaction);
        }

        public async Task<bool> ChangeStatusAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;
            entity.Status = !entity.Status;
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var exists = _dbSet.Any(x => x.Id == id);    
            if (!exists) return false;

            await _dbSet.Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(property => property.Deleted, true));

            return true;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}

internal class Transaction(IDbContextTransaction transaction) : ITransaction
{

    private IDbContextTransaction _transaction = transaction;


    public Task CommitAsync()
    {
        return _transaction.CommitAsync();
    }

    public Task RollbackAsync()
    {
        return _transaction.RollbackAsync();
    }
}
