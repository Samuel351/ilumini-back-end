namespace Ilumini.DTOs.Request
{
    public class UpdateFormRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public UpdateFormRequest()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
