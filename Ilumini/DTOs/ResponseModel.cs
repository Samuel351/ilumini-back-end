using System.Net;

namespace Ilumini.DTOs
{
    public class ResponseModel
    {
        public string? Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
