using FluentValidation;
using ShoppingSystem.Product.Application.Usecases.Product.Commands.UpdateProduct;

namespace ShoppingSystem.Product.Api.Validators;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid description");
    }
}
