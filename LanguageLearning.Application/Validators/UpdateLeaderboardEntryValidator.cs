using FluentValidation;
using LanguageLearning.Application.Features.Commands.UpdateCommands; 

namespace LanguageLearning.Application.Validators
{
    public class UpdateLeaderboardEntryValidator : AbstractValidator<UpdateLeaderboardEntryCommand>
    {
        public UpdateLeaderboardEntryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Leaderboard entry ID must be greater than 0.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0.");
            RuleFor(x => x.Score).GreaterThanOrEqualTo(0).WithMessage("Score must be 0 or greater.");
        }
    }
}
