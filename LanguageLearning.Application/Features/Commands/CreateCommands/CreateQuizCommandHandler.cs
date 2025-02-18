using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Domain.Enums;
using LanguageLearning.Application.Features.Commands.CreateCommands;

namespace LanguageLearning.Application.Features.Commands.CreateCommands
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, int>
    {
        private readonly IQuizRepository _quizRepository;

        public CreateQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<int> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new Quiz
            {
                Title = request.Title,
                DifficultyLevel = (DifficultyLevel)request.DifficultyLevel 
            };

            await _quizRepository.AddAsync(quiz);
            return quiz.Id;
        }
    }
}
