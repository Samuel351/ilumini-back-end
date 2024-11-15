using Ilumini.Presentation.DTOs.Request;
using Ilumini.Presentation.DTOs.Response;
using Ilumini.Services.Models;

namespace Ilumini.Services.Implementations
{
    public interface IOptionService
    {
        Result CreateOption(CreateOptionRequest request);

        Result<OptionResponse> GetFormById(Guid optionId);
    }
}
