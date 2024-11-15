using Ilumini.Presentation.DTOs.Request;
using Ilumini.Presentation.DTOs.Response;
using Ilumini.Services.Models;

namespace Ilumini.Services.Implementations
{
    public interface IQuestionService
    {
        Result CreateQuestion(CreateQuestionRequest request);

        Result<QuestionResponse> GetQuestionById(Guid questionId);
    }
}
