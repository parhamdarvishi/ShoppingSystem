using FluentValidation;
using ShppingSystem.Product.Api.Dtos;

namespace ShoppingSystem.Product.Api.Validators;

public class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
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
