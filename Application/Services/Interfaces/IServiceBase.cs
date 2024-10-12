using Application.Enums;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IServiceBase<T> where T: EntityBase
    {
        Task<Result<T>> CreateAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result> DeleteAsync(T entity);
        Task<Result<T>> GetByIdAsync(Guid id, CancellationToken? cancellationToken = null);
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result> ChangeStatusAsync(Guid id);
        Task<Result> DeleteById(Guid id);
        Task<Result<bool>> Exists(Guid id);
    }
}
