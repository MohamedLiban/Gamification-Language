using LanguageLearning.Application.Features.Commands.CreateCommands;
using LanguageLearning.Application.Features.Commands.DeleteCommands;
using LanguageLearning.Application.Features.Commands.UpdateCommands;
using LanguageLearning.Application.Features.Queries.Challenges;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LanguageLearning.Api.Controllers
{
    [Route("api/challenge")]
    [ApiController]
    
    public class ChallengeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChallengeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChallenge([FromBody] CreateChallengeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllChallenges()
        {
            var result = await _mediator.Send(new GetAllChallengesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChallengeById(int id)
        {
            var result = await _mediator.Send(new GetChallengeByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateChallenge(int id, [FromBody] UpdateChallengeCommand command)
        {
            if (id != command.ChallengeId)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteChallenge(int id)
        {
            var result = await _mediator.Send(new DeleteChallengeCommand(id));
            return result ? Ok("Challenge deleted") : NotFound();
        }
    }
}
