using FluentValidation;
using LanguageLearning.Application.Features.Commands.CreateCommands;

public class CreateQuizValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizValidator()
    {
        RuleFor(q => q.Title)
            .NotEmpty().WithMessage("Title is required");

        RuleFor(q => q.Description)
            .NotEmpty().WithMessage("Description is required") 
            .MinimumLength(5).WithMessage("Description must be at least 5 characters long");
    }
}
