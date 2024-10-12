using Domain.Entities;
using Domain.Enums;

namespace Ilumini.DTOs.Request
{
    public class UpdateQuestionRequest
    {
        public Guid FormId { get; set; }
        public Guid Id { get; set; }
        public string Statement { get; set; }

        public int Order { get; set; }

        public bool IsOpcional { get; set; }

        public LikertType LikertType { get; set; }

        public UpdateQuestionRequest()
        {
            Statement = string.Empty;
        }
    }
}
