using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wellness.Application.Features.Auth.Commands;
using Wellness.Application.Features.Register.Commands;

namespace Wellness.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
