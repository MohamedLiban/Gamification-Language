using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Domain.Enums;
using LanguageLearning.Application.Features.Commands.UpdateCommands;

namespace LanguageLearning.Application.Features.Commands.UpdateCommands
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, bool>
    {
        private readonly IQuizRepository _quizRepository;

        public UpdateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<bool> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);
            if (quiz == null) return false;

            quiz.Title = request.Title;
            quiz.DifficultyLevel = (DifficultyLevel)request.DifficultyLevel; 

            await _quizRepository.UpdateAsync(quiz);
            return true;
        }
    }
}
