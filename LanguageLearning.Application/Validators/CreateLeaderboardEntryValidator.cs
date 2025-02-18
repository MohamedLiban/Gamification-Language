using FluentValidation;
using LanguageLearning.Application.Features.Commands.CreateCommands;

public class CreateLeaderboardEntryValidator : AbstractValidator<CreateLeaderboardEntryCommand>
{
    public CreateLeaderboardEntryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.Score).GreaterThanOrEqualTo(0);
    }
}
