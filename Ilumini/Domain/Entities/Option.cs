namespace Ilumini.Domain.Entities
{
    public class Option : EntityBase
    {
        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public Guid QuestionId { get; set; }

        public Question? Question { get; set; }

    }
}
