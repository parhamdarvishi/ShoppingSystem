using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Shared.Response;

namespace ShoppingSystem.Product.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private ISender _mediator;
    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected async Task<ObjectResult> SendAsync(IRequest<Response> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);

        if (result.IsSuccess)
            return Ok(result);

        return new ObjectResult(result);
        //return new ObjectResult(result.ToProblemDetails())
        //{
        //    StatusCode = (int)result.StatusCode
        //};
    }

}
