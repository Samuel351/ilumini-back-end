namespace Ilumini.Presentation.DTOs.Response
{
    public class FormInstanceResponse
    {
        public string Link { get; set; } = string.Empty;

        public FormInstanceResponse() { }

        public FormInstanceResponse(string link)
        {
            Link = link;
        }
    }
}
