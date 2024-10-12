using Domain.Entities;
using Domain.Enums;

namespace Ilumini.DTOs.Response
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }

        public int Order { get; set; }

        public LikertType QuestionType { get; set; }

        public QuestionResponse()
        {
            Statement = string.Empty;
        }

        public QuestionResponse(Question question)
        {
            Id = question.Id;
            Statement = question.Statement;
            QuestionType = question.LikertType;
            Order = question.Order;
        }
    }
}
