namespace Ilumini.Domain.Entities
{
    public class Response
    {
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }
        public Guid OptionId { get; set; }
        public Option? Option { get; set; }
        public Guid FormInstanceId { get; set; }
        public FormInstance? FormInstance { get; set; }
        public Guid RecipientId { get; set; }
        public string Recipient { get; set; } = string.Empty;

        public Response()
        {

        }

        public Response(Guid questionId, Guid optionId, Guid formInstanceId, Guid recipientId, string recipient)
        {
            QuestionId = questionId;
            OptionId = optionId;
            FormInstanceId = formInstanceId;
            RecipientId = recipientId;
            Recipient = recipient;
        }
    }
}
