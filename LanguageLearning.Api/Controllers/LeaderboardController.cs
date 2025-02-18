using System.Threading.Tasks;
using LanguageLearning.Application.Features.Leaderboard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Api.Controllers
{
    
    [ApiController]
    [Route("api/leaderboard")]
    public class LeaderboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaderboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var result = await _mediator.Send(new GetLeaderboardQuery());
            return Ok(result);
        }
    }
}
