using FluentValidation;
using LanguageLearning.Application.Features.Commands.CreateCommands;

public class CreateUserProgressValidator : AbstractValidator<CreateUserProgressCommand>
{
    public CreateUserProgressValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.ChallengeId).GreaterThan(0);
        RuleFor(x => x.Progress).InclusiveBetween(0, 100);
    }
}
