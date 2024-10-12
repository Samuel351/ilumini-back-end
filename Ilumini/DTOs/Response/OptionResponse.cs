using Domain.Entities;

namespace Ilumini.DTOs.Response
{
    public class OptionResponse
    {
        public string Statement { get; set; }

        public int Value { get; set; }

        public int Order { get; set; }

        public OptionResponse() { }

        public OptionResponse(Option option)
        {
            Statement = option.Statement;
            Value = option.Value;
            Order = option.Order;
        }
    }
}
