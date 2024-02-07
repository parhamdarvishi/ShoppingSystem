using ShoppingSystem.Shared.Output;
using ShoppingSystem.Shared.Setting;
using System.Net;

namespace ShoppingSystem.Shared.Response;

public partial class Response
{
    public Errors[] Errors { get; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; protected set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
}

public partial class Response
{
    protected Response(Errors[] errors = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Errors = errors;
        IsSuccess = errors is null;
        Message = IsSuccess ? ResponseSettings.DefaultSuccessMessage : null;
        StatusCode = statusCode;
    }

    public static Response Success() => new();
    public static Response<T> Success<T>(T result) => new(result);
    public static Response Failure(params Errors[] errors) => new(errors);
    public static Response<T> Failure<T>(params Errors[] errors) => new(default, errors);

    public Response WithMessage(string message)
    {
        Message = message;
        return this;
    }

    public Response WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }
}

public class Response<T>(T result, Errors[] errors = null) : Response(errors)
{
    public T Result { get; init; } = result;
}