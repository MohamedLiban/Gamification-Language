using FluentValidation;
using LanguageLearning.Application.Features.Commands.UpdateCommands;

public class UpdateQuizValidator : AbstractValidator<UpdateQuizCommand>
{
    public UpdateQuizValidator()
    {
        RuleFor(x => x.QuizId).GreaterThan(0);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.DifficultyLevel).InclusiveBetween(1, 5);
    }
}
