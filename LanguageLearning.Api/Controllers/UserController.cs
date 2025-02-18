using System.Threading.Tasks;
using LanguageLearning.Application.Features.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Api.Controllers
{
    
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(result);
        }
    }
}
