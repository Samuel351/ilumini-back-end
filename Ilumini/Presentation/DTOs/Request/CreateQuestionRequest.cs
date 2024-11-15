namespace Ilumini.Presentation.DTOs.Request
{
    public class CreateQuestionRequest
    {
        public string Statement { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool IsOpcional { get; set; }

        public List<CreateOptionRequest> Options { get; set; } = [];
    }
}
