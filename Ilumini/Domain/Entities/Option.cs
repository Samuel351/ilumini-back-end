namespace Ilumini.Domain.Entities
{
    public class Option : EntityBase
    {
        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public Guid QuestionId { get; set; }

        public Question? Question { get; set; }

        public Option()
        {

        }

        public Option(string statement, int position, Guid? questionId)
        {
            Statement = statement;
            Position = position;
            if (questionId.HasValue)
            {
                QuestionId = questionId.Value;
            }
        }
    }
}
