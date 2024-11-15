using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Request
{
    public class CreateOptionRequest
    {
        public Guid? QuestionId { get; set; }
        public string Statement { get; set; } = string.Empty;
        public int Position { get; set; }

        public Option ToEntity()
        {
            return new Option(Statement, Position, QuestionId);
        }
    }
}
