namespace Ilumini.DTOs.Request
{
    public class SubmitResponseRequest
    {
        public Guid FormInstanceId  { get; set; }

        public Guid OptionId { get; set; }

        public Guid RecipientId { get; set; }
    }
}
