using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wellness.Application.Features.Habit.Commands;

namespace Wellness.API.Controllers
{
    [ApiController]
    [Route("api/habits")]
    public class HabitController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateHabitCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateHabitCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(
                new DeleteHabitCommand
                {
                    Id = id
                });

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _mediator.Send(
                new GetHabitsQuery
                {
                    UserId = userId
                });

            return Ok(result);
        }
    }
}
