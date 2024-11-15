using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Response
{
    public class FormResponse
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<QuestionResponse> Questions { get; set; } = [];

        public FormResponse() { }

        public FormResponse(Form form)
        {
            Id = form.Id;
            Name = form.Name;
            Description = form.Description;
            Questions = form.Questions.Select(x => new QuestionResponse(x)).ToList();
        }
    }
}
