using Ilumini.Presentation.DTOs.Request;
using Ilumini.Presentation.DTOs.Response;
using Ilumini.Services.Models;

namespace Ilumini.Services.Implementations
{
    public interface IFormService
    {
        Result CreateForm(CreateFormRequest request);

        Result<FormResponse> GetFormById(Guid formId);

        Result<FormInstanceResponse> LauchForm(Guid formId);

        Result<FormResponse> GetFormByInstance(Guid instanceId);
    }
}
