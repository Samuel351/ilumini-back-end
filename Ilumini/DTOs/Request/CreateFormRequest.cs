namespace Ilumini.DTOs.Request
{
    public class CreateFormRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CreateFormRequest() 
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
