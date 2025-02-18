using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearning.Application.Interfaces;
using LanguageLearning.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Api.Controllers
{
    [ApiController]
    [Route("api/userprogress")]
    public class UserProgressController : ControllerBase
    {
        private readonly IUserProgressRepository _userProgressRepository;

        public UserProgressController(IUserProgressRepository userProgressRepository)
        {
            _userProgressRepository = userProgressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var progresses = await _userProgressRepository.GetAllAsync();
            return Ok(progresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var progress = await _userProgressRepository.GetByIdAsync(id);
            if (progress == null)
                return NotFound();
            return Ok(progress);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserProgress progress)
        {
            await _userProgressRepository.AddAsync(progress);
            return CreatedAtAction(nameof(GetById), new { id = progress.Id }, progress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserProgress progress)
        {
            if (id != progress.Id)
                return BadRequest();

            await _userProgressRepository.UpdateAsync(progress);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userProgressRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
