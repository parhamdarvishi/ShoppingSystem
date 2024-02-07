using System.ComponentModel;

namespace ShoppingSystem.Shared.Output;

public enum ErrorType
{
    [Description("Bad Request")]
    VALIDATION = 400,

    [Description("Internal Server Error")]
    FAILURE = 500,

    [Description("Not Found")]
    NOT_FOUND = 404,

    [Description("Unauthorized Access")]
    UNAUTHORIZED = 401,

    [Description("Internal Server Error")]
    NONE = 100
}
