using Application.Enums;
using Application.Models;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<T> CreateAsync(T entity);

        Task<IEnumerable<T>> CreateAllAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T?> GetByIdAsync(Guid id, CancellationToken? cancellationToken);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> ChangeStatusAsync(Guid id);

        Task<bool> DeleteById(Guid id);

        Task<bool> Exists(Guid id);

    }
}
