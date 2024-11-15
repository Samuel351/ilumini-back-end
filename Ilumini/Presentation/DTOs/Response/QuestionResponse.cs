namespace Ilumini.Presentation.DTOs.Response
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }

        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public bool IsOpcional { get; set; }

        public List<OptionResponse> Options { get; set; } = [];
    }
}
