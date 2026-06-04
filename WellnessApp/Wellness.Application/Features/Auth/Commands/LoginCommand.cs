using MediatR;
using Wellness.Application.DTOs;

namespace Wellness.Application.Features.Auth.Commands
{
    public sealed record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;
}
