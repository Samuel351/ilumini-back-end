using Application.Enums;
using System.Net;

namespace Application.Models.Errors;

public class ErrorModel // TODO
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public ErrorType ErrorType { get; set; } 

    public ErrorModel()
    {
        
    }

    public ErrorModel(string title, string message, ErrorType errorType)
    {
        Title = title;
        Message = message;
        ErrorType = errorType;
    }
}


