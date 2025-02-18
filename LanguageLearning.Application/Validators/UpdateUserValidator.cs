using FluentValidation;
using LanguageLearning.Application.Features.Commands.UpdateCommands;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
