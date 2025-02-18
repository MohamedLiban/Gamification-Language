using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Application.Features.Commands.CreateCommands;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using LanguageLearning.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Api.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;

        public QuizController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizCommand command)
        {
            if (!Enum.IsDefined(typeof(DifficultyLevel), command.DifficultyLevel))
            {
                return BadRequest("Invalid difficulty level.");
            }

            var quiz = new Quiz
            {
                Title = command.Title,
                Description = command.Description,
                DifficultyLevel = (DifficultyLevel)command.DifficultyLevel  
            };

            await _quizRepository.AddAsync(quiz);
            return Ok(quiz);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizRepository.GetAllAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById(int id)
        {
            var quiz = await _quizRepository.GetByIdAsync(id);
            if (quiz == null)
                return NotFound();

            return Ok(quiz);
        }
    }
}
