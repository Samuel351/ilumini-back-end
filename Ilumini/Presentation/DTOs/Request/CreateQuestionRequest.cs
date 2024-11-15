using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Request
{
    public class CreateQuestionRequest
    {
        public Guid? FormId { get; set; }
        public string Statement { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool IsOpcional { get; set; }

        public List<CreateOptionRequest> Options { get; set; } = [];


        public Question ToEntity()
        {
            return new Question(Statement, Position, IsOpcional, Options.Select(x => x.ToEntity()).ToList(), FormId);
        }
    }
}
