using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wellness.Application.Features.Roles.Commands;

namespace Wellness.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(
                new GetRolesQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(
                new DeleteRoleCommand
                {
                    Id = id
                });

            return Ok(result);
        }
    }
}