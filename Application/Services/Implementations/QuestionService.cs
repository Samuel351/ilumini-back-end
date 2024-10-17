using Application.Consts;
using Application.Enums;
using Application.Models;
using Application.Models.Errors;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Services.Implementations
{
    public class QuestionService(IQuestionRepository repository, ILogger<IServiceBase<Question>> logger) : ServiceBase<Question>(repository, logger), IQuestionService
    {

        private readonly IQuestionRepository _repository = repository;

        private readonly ILogger<IServiceBase<Question>> _logger = logger;

        public override Task<Result<Question>> CreateAsync(Question entity)
        {
            entity.Options = LikertScale.GetScalePreSet(entity.LikertType);

            return base.CreateAsync(entity);
        }

        public async Task<Result> CreateBatch(List<Question> questions)
        {
            questions.ForEach(async x =>
            {
                x.Options = LikertScale.GetScalePreSet(x.LikertType);

                _ = await base.CreateAsync(x);
            });

            return Result.Empty();
        }
        
        public Task<Result> UpdateBatch(List<Question> questions)
        {
            questions.ForEach(async x =>
            {
                x.Options = LikertScale.GetScalePreSet(x.LikertType);

                _ = await base.UpdateAsync(x);
            });

            return Task.FromResult(Result.Empty());
        }

        public override Task<Result<Question>> UpdateAsync(Question entity)
        {
            entity.Options = LikertScale.GetScalePreSet(entity.LikertType);

            return base.UpdateAsync(entity);
        }

        public async Task<Result<IEnumerable<Question>>> GetQuestionsByFormId(Guid formId)
        {
            var result = await _repository.GetQuestionsByFormId(formId);

            if (!result.Any()) return Result.ForError<IEnumerable<Question>>(new ErrorModel(string.Empty, "Sem conteúdo", ErrorType.NO_CONTENT));

            return Result.Success(result);
        }
    }
}
