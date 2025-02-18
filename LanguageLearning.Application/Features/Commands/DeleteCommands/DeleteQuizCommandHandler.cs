using LanguageLearning.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Application.Features.Commands.DeleteCommands;
namespace LanguageLearning.Application.Features.Commands.DeleteCommands
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, bool>
    {
        private readonly IQuizRepository _quizRepository;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<bool> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.QuizId);
            if (quiz == null) return false;

            await _quizRepository.DeleteAsync(quiz.Id);
            return true;

        }
    }
}
