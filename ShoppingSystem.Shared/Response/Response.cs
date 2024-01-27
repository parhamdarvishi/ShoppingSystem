using System.Net;

namespace ShoppingSystem.Shared.Response;

public class Response
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

    public Response(string message, HttpStatusCode statusCode)
    {
        Message = message;
        StatusCode = statusCode;
        if (StatusCode != HttpStatusCode.OK)
            IsSuccess = false;
    }
}
