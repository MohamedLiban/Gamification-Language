using FluentValidation;
using LanguageLearning.Application.Features.Commands.CreateCommands;

namespace LanguageLearning.Application.Validators
{
    public class CreateChallengeValidator : AbstractValidator<CreateChallengeCommand>
    {
        public CreateChallengeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

           
        }
    }
}
