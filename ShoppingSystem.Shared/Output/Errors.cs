namespace ShoppingSystem.Shared.Output;

public class Errors
{
    public string Message { get; }

    protected Errors(string message)
    {
        Message = message;
    }

}
