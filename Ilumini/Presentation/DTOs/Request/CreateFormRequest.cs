using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Request
{
    public class CreateFormRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<CreateQuestionRequest> Questions { get; set; } = [];
    }
}
