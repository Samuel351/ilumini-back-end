using Application.Enums;
using Application.Models;
using Application.Models.Errors;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Services.Implementations
{
    public class ServiceBase<T>(IRepositoryBase<T> repository, ILogger<IServiceBase<T>> logger) : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository = repository;
        private readonly ILogger<IServiceBase<T>> _logger = logger;

        public virtual async Task<Result> ChangeStatusAsync(Guid id)
        {

            var entity = await _repository.GetByIdAsync(id, null);

            if(entity == null) return Result.ForError(new NotFoundErrorModel());

            entity.Status = !entity.Status;

            entity = await _repository.UpdateAsync(entity);

            return Result.Success(true);
        }

        public virtual async Task<Result<T>> CreateAsync(T entity)
        {
            try
            {
                await _repository.CreateAsync(entity);
                return Result.Success(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result.ForError<T>(ex);
            }
        }

        public virtual async Task<Result> DeleteAsync(T entity)
        {
            try
            {
                await _repository.DeleteAsync(entity);
                return Result.Empty();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result.ForError(ex);
            }
        }

        public virtual async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            IEnumerable<T> all = await _repository.GetAllAsync();
            return Result.Success(all);
        }

        public virtual async Task<Result<T>> GetByIdAsync(Guid id, CancellationToken? cancellationToken = null)
        {
            T? found = await _repository.GetByIdAsync(id, cancellationToken);

            if (found == null)
                return Result.ForError<T>(new NotFoundErrorModel());

            return Result.Success(found);
        }

        public virtual async Task<Result<T>> UpdateAsync(T entity)
        {
            try
            {
                if(await _repository.Exists(entity.Id))
                {
                    T updated = await _repository.UpdateAsync(entity);
                    return Result.Success(updated);
                }

                return Result.ForError<T>(new NotFoundErrorModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Result.ForError<T>(ex);
            }
        }

        public virtual async Task<Result> DeleteById(Guid id)
        {
            var response = await _repository.DeleteById(id);

            if (!response) return Result.ForError(new ErrorModel("Deleção de entidade", "Erro ao deletar entidade", ErrorType.EXCEPTION));

            return Result.Success(response);
        }

        public virtual async Task<Result<bool>> Exists(Guid id)
        {
            var response = await _repository.Exists(id);
            return Result.Success(response);
        }
    }
}
