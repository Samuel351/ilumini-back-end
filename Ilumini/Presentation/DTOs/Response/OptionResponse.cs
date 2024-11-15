using Ilumini.Domain.Entities;

namespace Ilumini.Presentation.DTOs.Response
{
    public class OptionResponse
    {
        public Guid Id { get; set; }

        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public OptionResponse() { }

        public OptionResponse(Option option)
        {
            Id = option.Id;
            Statement = option.Statement;
            Position = option.Position;
        }
    }
}
