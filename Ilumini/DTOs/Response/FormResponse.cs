using Domain.Entities;

namespace Ilumini.DTOs.Response
{
    public class FormResponse
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<QuestionResponse> Questions { get; set; }

        public FormResponse()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public FormResponse(Form form)
        {
            Id = form.Id;
            Name = form.Name;
            Description = form.Description;
            Questions = form.Questions.Select(x => new QuestionResponse(x)).ToList();
        }
    }
}
