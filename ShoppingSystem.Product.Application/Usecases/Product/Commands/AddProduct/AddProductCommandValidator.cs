using FluentValidation;
using ShoppingSystem.Product.Application.Usecases.Product.Commands.AddProduct;

namespace ShoppingSystem.Product.Api.Validators;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");

        RuleFor(x => x.description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please enter valid description");
    }
}
