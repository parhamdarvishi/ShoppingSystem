using FluentValidation;
using ShoppingSystem.Content.Application.Dtos.Content;

namespace ShoppingSystem.Content.Api.Profile
{
    public class AddContentDtoValidator : AbstractValidator<AddContentDto>
    {
        public AddContentDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .WithMessage("please enter valid title.");

            RuleFor(x => x.Description)
               .NotEmpty()
               .NotNull()
               .MinimumLength(2)
               .WithMessage("please enter valid description.");
        }
    }
}
