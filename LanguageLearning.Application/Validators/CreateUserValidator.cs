using FluentValidation;
using LanguageLearning.Application.Features.Authentication;

public class CreateUserValidator : AbstractValidator<RegisterUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
