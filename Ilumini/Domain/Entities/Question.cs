namespace Ilumini.Domain.Entities
{
    public class Question : EntityBase
    {
        public string Statement { get; set; } = string.Empty;

        public int Position { get; set; }

        public bool IsOpcional { get; set; }

        public Guid FormId { get; set; }

        public Form? Form { get; set; }

        public List<Option> Options { get; set; } = [];

    }
}
