namespace Ilumini.Domain.Entities
{
    public class FormInstance : EntityBase
    {
        public Guid FormId { get; set; }

        public Form? Form { get; set; }

        public DateTime? EndAt { get; set; }

        public List<Response> Responses { get; set; } = [];

        public FormInstance() { }

        public FormInstance(Guid formId)
        {
            FormId = formId;
        }

    }
}
