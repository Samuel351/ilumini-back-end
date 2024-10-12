namespace Ilumini.DTOs.Request
{
    public class CustomOptionRequest
    {
        public string Statement { get; set; }

        public int Order { get; set; }

        public CustomOptionRequest()
        {
            Statement = string.Empty;
        }

        public CustomOptionRequest(string statement, int order)
        {
            Statement = statement;
            Order = order;
        }
    }
}
