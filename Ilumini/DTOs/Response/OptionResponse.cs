using Domain.Entities;

namespace Ilumini.DTOs.Response
{
    public class OptionResponse
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }

        public int Value { get; set; }

        public int Order { get; set; }

        public OptionResponse() { }

        public OptionResponse(Option option)
        {
            Id = option.Id;
            Statement = option.Statement;
            Value = option.Value;
            Order = option.Order;
        }
    }
}
