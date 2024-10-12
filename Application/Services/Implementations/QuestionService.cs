using Application.Consts;
using Application.Enums;
using Application.Models;
using Application.Models.Errors;
using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations
{
    public class QuestionService(IQuestionRepository repository, ILogger<IServiceBase<Question>> logger) : ServiceBase<Question>(repository, logger), IQuestionService
    {

        private readonly IQuestionRepository _repository = repository;

        public override Task<Result<Question>> CreateAsync(Question entity)
        {
            switch(entity.LikertType)
            {
                case LikertType.AgreementScale:
                    entity.Options = [.. LikertScale.AgreementScale];
                    break;
                case LikertType.ImportanceScale:
                    entity.Options = [.. LikertScale.ImportanceScale];
                    break;
                case LikertType.FrequencyScale:
                    entity.Options = [.. LikertScale.FrequencyScale];
                    break;
            }

            return base.CreateAsync(entity);
        }

        public override Task<Result<Question>> UpdateAsync(Question entity)
        {

            switch (entity.LikertType)
            {
                case LikertType.AgreementScale:
                    entity.Options = [.. LikertScale.AgreementScale];
                    break;
                case LikertType.ImportanceScale:
                    entity.Options = [.. LikertScale.ImportanceScale];
                    break;
                case LikertType.FrequencyScale:
                    entity.Options = [.. LikertScale.FrequencyScale];
                    break;
            }

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
