using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Response
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }

        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public bool IsOpcional { get; set; }

        public List<OptionResponse> Options { get; set; } = [];

        public QuestionResponse() { }

        public QuestionResponse(Question question)
        {
            Id = question.Id;
            Statement = question.Statement;
            Position = question.Position;
            IsOpcional = question.IsOpcional;
            Options = question.Options.Select(x => new OptionResponse(x)).ToList();
        }
    }
}
