namespace Ilumini.Presentation.DTOs.Response
{
    public class FormAnswerRequest
    {
        public Guid QuestionId { get; set; }
        public Guid OptionId { get; set; }
        public Guid FormInstanceId { get; set; }
        public Guid RecipientId { get; set; }
        public string? Recipient { get; set; } = string.Empty;

        public Domain.Entities.Response ToEntity()
        {
            return new Domain.Entities.Response(QuestionId, OptionId, FormInstanceId, RecipientId, Recipient ?? "");
        }

    }
}
