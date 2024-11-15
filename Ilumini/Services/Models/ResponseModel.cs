using System.Net;

namespace Ilumini.Services.Models
{
    public class ResponseModel
    {
        public string Message { get; } = string.Empty;

        public int StatusCode { get; }

        public ResponseModel(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = (int)statusCode;
        }

    }
}
