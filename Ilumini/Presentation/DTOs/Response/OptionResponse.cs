namespace Ilumini.Presentation.DTOs.Response
{
    public class OptionResponse
    {
        public Guid Id { get; set; }

        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }
    }
}
