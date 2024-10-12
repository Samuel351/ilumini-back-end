using Domain.Enums;

namespace Ilumini.DTOs.Request
{
    public class CreateQuestionRequest
    {

        public Guid FormId { get; set; }

        public string Statement { get; set; }

        public int Order { get; set; }

        public bool IsOpcional { get; set; }

        public LikertType LikertType { get; set; }

        public CreateQuestionRequest()
        {
            Statement = string.Empty;
        }

        public CreateQuestionRequest(string statement, int order)
        {
            Statement = statement;
            Order = order;
        }
    }
}
